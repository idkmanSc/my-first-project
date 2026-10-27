namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTaskTitle = new TextBox();
            txtTaskDesc = new TextBox();
            chkIsDone = new CheckBox();
            btnAddTask = new Button();
            btnUpdateTask = new Button();
            btnDeleteTask = new Button();
            dgvTasks = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // txtTaskTitle
            // 
            txtTaskTitle.Location = new Point(52, 12);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.Size = new Size(131, 23);
            txtTaskTitle.TabIndex = 0;
            // 
            // txtTaskDesc
            // 
            txtTaskDesc.Location = new Point(52, 41);
            txtTaskDesc.Name = "txtTaskDesc";
            txtTaskDesc.Size = new Size(131, 23);
            txtTaskDesc.TabIndex = 1;
            // 
            // chkIsDone
            // 
            chkIsDone.AutoSize = true;
            chkIsDone.Location = new Point(52, 70);
            chkIsDone.Name = "chkIsDone";
            chkIsDone.Size = new Size(90, 19);
            chkIsDone.TabIndex = 2;
            chkIsDone.Text = "Выполнено";
            chkIsDone.UseVisualStyleBackColor = true;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(52, 371);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(131, 39);
            btnAddTask.TabIndex = 3;
            btnAddTask.Text = "Добавить задачу";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnUpdateTask
            // 
            btnUpdateTask.Location = new Point(189, 371);
            btnUpdateTask.Name = "btnUpdateTask";
            btnUpdateTask.Size = new Size(131, 39);
            btnUpdateTask.TabIndex = 4;
            btnUpdateTask.Text = "Обновить задачу";
            btnUpdateTask.UseVisualStyleBackColor = true;
            btnUpdateTask.Click += btnUpdateTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(326, 371);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(131, 39);
            btnDeleteTask.TabIndex = 5;
            btnDeleteTask.Text = "Удалить задачу";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // dgvTasks
            // 
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(52, 95);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.Size = new Size(370, 270);
            dgvTasks.TabIndex = 6;
            dgvTasks.CellClick += dgvTasks_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 420);
            Controls.Add(dgvTasks);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnUpdateTask);
            Controls.Add(btnAddTask);
            Controls.Add(chkIsDone);
            Controls.Add(txtTaskDesc);
            Controls.Add(txtTaskTitle);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTaskTitle;
        private TextBox txtTaskDesc;
        private CheckBox chkIsDone;
        private Button btnAddTask;
        private Button btnUpdateTask;
        private Button btnDeleteTask;
        private DataGridView dgvTasks;
    }
}
