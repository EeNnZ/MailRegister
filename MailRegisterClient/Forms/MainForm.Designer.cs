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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            registerButton = new Button();
            modifyButton = new Button();
            deleteButton = new Button();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            checkDraftsButton = new Button();
            dataGridView = new DataGridView();
            label1 = new Label();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // registerButton
            // 
            registerButton.Anchor = AnchorStyles.None;
            registerButton.BackColor = Color.FromArgb(61, 165, 244);
            registerButton.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            registerButton.FlatAppearance.BorderSize = 2;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.Font = new Font("SF Pro Display", 12F, FontStyle.Regular, GraphicsUnit.Point);
            registerButton.ForeColor = Color.Snow;
            registerButton.Location = new Point(687, 12);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(93, 39);
            registerButton.TabIndex = 1;
            registerButton.Text = "New";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // modifyButton
            // 
            modifyButton.Anchor = AnchorStyles.None;
            modifyButton.BackColor = Color.FromArgb(61, 165, 244);
            modifyButton.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            modifyButton.FlatAppearance.BorderSize = 2;
            modifyButton.FlatStyle = FlatStyle.Flat;
            modifyButton.Font = new Font("SF Pro Display", 12F, FontStyle.Regular, GraphicsUnit.Point);
            modifyButton.ForeColor = Color.Snow;
            modifyButton.Location = new Point(786, 12);
            modifyButton.Name = "modifyButton";
            modifyButton.Size = new Size(93, 39);
            modifyButton.TabIndex = 2;
            modifyButton.Text = "Modify";
            modifyButton.UseVisualStyleBackColor = false;
            modifyButton.Click += modifyButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.None;
            deleteButton.BackColor = Color.FromArgb(34, 36, 62);
            deleteButton.FlatAppearance.BorderColor = Color.Brown;
            deleteButton.FlatAppearance.BorderSize = 2;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point);
            deleteButton.ForeColor = Color.Snow;
            deleteButton.Location = new Point(885, 12);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(93, 39);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(29, 36, 62);
            statusStrip.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 529);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(990, 22);
            statusStrip.TabIndex = 4;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.ForeColor = Color.WhiteSmoke;
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(137, 17);
            toolStripStatusLabel.Text = "toolStripStatusLabel2";
            // 
            // checkDraftsButton
            // 
            checkDraftsButton.BackColor = Color.FromArgb(224, 224, 224);
            checkDraftsButton.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            checkDraftsButton.FlatAppearance.BorderSize = 2;
            checkDraftsButton.FlatStyle = FlatStyle.Flat;
            checkDraftsButton.Font = new Font("SF Pro Display", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkDraftsButton.ForeColor = Color.DarkRed;
            checkDraftsButton.Location = new Point(885, 486);
            checkDraftsButton.Name = "checkDraftsButton";
            checkDraftsButton.Size = new Size(93, 39);
            checkDraftsButton.TabIndex = 5;
            checkDraftsButton.Text = "Drafts";
            checkDraftsButton.UseVisualStyleBackColor = false;
            checkDraftsButton.Click += checkDraftsButton_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(39, 49, 70);
            dataGridViewCellStyle1.Font = new Font("SF Pro Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(19, 24, 41);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.FromArgb(39, 49, 70);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(64, 0, 64);
            dataGridViewCellStyle2.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(64, 0, 64);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeight = 50;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(37, 46, 81);
            dataGridViewCellStyle3.Font = new Font("SF Pro Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(19, 24, 41);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.Location = new Point(0, 60);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(39, 49, 70);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(64, 0, 64);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.RowTemplate.Height = 50;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(990, 420);
            dataGridView.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 28F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(112, 45);
            label1.TabIndex = 7;
            label1.Text = "Mails";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 49, 70);
            ClientSize = new Size(990, 551);
            Controls.Add(label1);
            Controls.Add(dataGridView);
            Controls.Add(checkDraftsButton);
            Controls.Add(statusStrip);
            Controls.Add(deleteButton);
            Controls.Add(modifyButton);
            Controls.Add(registerButton);
            MinimumSize = new Size(1006, 590);
            Name = "MainForm";
            Text = "Mail Register";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button registerButton;
        private Button modifyButton;
        private Button deleteButton;
        private StatusStrip statusStrip;
        private Button checkDraftsButton;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private DataGridView dataGridView;
        private Label label1;
    }
}