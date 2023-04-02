namespace MailRegisterClient
{
    partial class MainForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView = new DataGridView();
            registerButton = new Button();
            modifyButton = new Button();
            deleteButton = new Button();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            checkDraftsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlLight;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.BackgroundColor = SystemColors.ControlLight;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.Location = new Point(12, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(867, 504);
            dataGridView.TabIndex = 0;
            // 
            // registerButton
            // 
            registerButton.BackColor = SystemColors.Control;
            registerButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            registerButton.Location = new Point(885, 12);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(93, 39);
            registerButton.TabIndex = 1;
            registerButton.Text = "New";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // modifyButton
            // 
            modifyButton.BackColor = SystemColors.Control;
            modifyButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            modifyButton.Location = new Point(885, 73);
            modifyButton.Name = "modifyButton";
            modifyButton.Size = new Size(93, 39);
            modifyButton.TabIndex = 2;
            modifyButton.Text = "Modify";
            modifyButton.UseVisualStyleBackColor = false;
            modifyButton.Click += modifyButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = SystemColors.Control;
            deleteButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            deleteButton.Location = new Point(885, 134);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(93, 39);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = SystemColors.ControlLight;
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 529);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(990, 22);
            statusStrip.TabIndex = 4;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // checkDraftsButton
            // 
            checkDraftsButton.BackColor = SystemColors.Control;
            checkDraftsButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkDraftsButton.Location = new Point(885, 195);
            checkDraftsButton.Name = "checkDraftsButton";
            checkDraftsButton.Size = new Size(93, 39);
            checkDraftsButton.TabIndex = 5;
            checkDraftsButton.Text = "Drafts";
            checkDraftsButton.UseVisualStyleBackColor = false;
            checkDraftsButton.Click += checkDraftsButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(990, 551);
            Controls.Add(checkDraftsButton);
            Controls.Add(statusStrip);
            Controls.Add(deleteButton);
            Controls.Add(modifyButton);
            Controls.Add(registerButton);
            Controls.Add(dataGridView);
            MinimumSize = new Size(1006, 590);
            Name = "MainForm";
            Text = "Mail Register";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Button registerButton;
        private Button modifyButton;
        private Button deleteButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private Button checkDraftsButton;
    }
}