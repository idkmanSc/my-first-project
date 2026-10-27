using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=todo.db;Version=3;";
        private int selectedTaskId = 0;

        public Form1()
        {
            InitializeComponent();
            InitDatabase();
            LoadTasks();
        }

        private void InitDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Tasks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Description TEXT,
                        IsDone INTEGER DEFAULT 0
                    );";
                using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadTasks()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string selectQuery = "SELECT Id, Title AS 'Задача', Description AS 'Описание', IsDone AS 'Готово' FROM Tasks";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectQuery, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTasks.DataSource = dt;
                }
            }

            if (dgvTasks.Columns["Id"] != null)
            {
                dgvTasks.Columns["Id"].Visible = false;
            }

            ClearFields();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Введите название задачи!");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO Tasks (Title, Description, IsDone) VALUES (@Title, @Description, 0);";

                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", txtTaskTitle.Text);
                    cmd.Parameters.AddWithValue("@Description", txtTaskDesc.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadTasks();
        }

        private void dgvTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTasks.Rows[e.RowIndex];

                selectedTaskId = Convert.ToInt32(row.Cells["Id"].Value);
                txtTaskTitle.Text = row.Cells["Задача"].Value.ToString();
                txtTaskDesc.Text = row.Cells["Описание"].Value.ToString();

                int isDoneVal = Convert.ToInt32(row.Cells["Готово"].Value);
                chkIsDone.Checked = (isDoneVal == 1);
            }
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            if (selectedTaskId == 0)
            {
                MessageBox.Show("Выберите задачу из списка!");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE Tasks SET Title = @Title, Description = @Description, IsDone = @IsDone WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", selectedTaskId);
                    cmd.Parameters.AddWithValue("@Title", txtTaskTitle.Text);
                    cmd.Parameters.AddWithValue("@Description", txtTaskDesc.Text);
                    cmd.Parameters.AddWithValue("@IsDone", chkIsDone.Checked ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadTasks();
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (selectedTaskId == 0)
            {
                MessageBox.Show("Выберите задачу для удаления!");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Tasks WHERE Id = @Id;";
                using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", selectedTaskId);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadTasks();
        }

        private void ClearFields()
        {
            selectedTaskId = 0;
            txtTaskTitle.Clear();
            txtTaskDesc.Clear();
            chkIsDone.Checked = false;
        }

       
        

        
    }
}
