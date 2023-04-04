namespace MailRegisterClient
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nameTextBox = new TextBox();
            groupBox = new GroupBox();
            addresseeComboBox = new ComboBox();
            senderComboBox = new ComboBox();
            dateTimePicker = new DateTimePicker();
            labelBody = new Label();
            labelAddressee = new Label();
            labelSender = new Label();
            labelDate = new Label();
            labelName = new Label();
            bodyTextBox = new TextBox();
            confirmButton = new Button();
            draftButton = new Button();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = Color.FromArgb(39, 49, 70);
            nameTextBox.ForeColor = Color.WhiteSmoke;
            nameTextBox.Location = new Point(88, 32);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(387, 27);
            nameTextBox.TabIndex = 0;
            // 
            // groupBox
            // 
            groupBox.Controls.Add(addresseeComboBox);
            groupBox.Controls.Add(senderComboBox);
            groupBox.Controls.Add(dateTimePicker);
            groupBox.Controls.Add(labelBody);
            groupBox.Controls.Add(labelAddressee);
            groupBox.Controls.Add(labelSender);
            groupBox.Controls.Add(labelDate);
            groupBox.Controls.Add(labelName);
            groupBox.Controls.Add(bodyTextBox);
            groupBox.Controls.Add(nameTextBox);
            groupBox.Font = new Font("SF Pro Display", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox.ForeColor = Color.WhiteSmoke;
            groupBox.Location = new Point(12, 12);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(606, 522);
            groupBox.TabIndex = 1;
            groupBox.TabStop = false;
            groupBox.Text = "Mail";
            // 
            // addresseeComboBox
            // 
            addresseeComboBox.BackColor = Color.FromArgb(39, 49, 70);
            addresseeComboBox.ForeColor = Color.WhiteSmoke;
            addresseeComboBox.FormattingEnabled = true;
            addresseeComboBox.Location = new Point(88, 207);
            addresseeComboBox.Name = "addresseeComboBox";
            addresseeComboBox.Size = new Size(387, 27);
            addresseeComboBox.TabIndex = 12;
            // 
            // senderComboBox
            // 
            senderComboBox.BackColor = Color.FromArgb(39, 49, 70);
            senderComboBox.ForeColor = Color.WhiteSmoke;
            senderComboBox.FormattingEnabled = true;
            senderComboBox.Location = new Point(88, 149);
            senderComboBox.Name = "senderComboBox";
            senderComboBox.Size = new Size(387, 27);
            senderComboBox.TabIndex = 11;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CalendarFont = new Font("SF Pro Display", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker.CalendarForeColor = Color.WhiteSmoke;
            dateTimePicker.CalendarMonthBackground = Color.FromArgb(39, 49, 70);
            dateTimePicker.CalendarTitleForeColor = Color.WhiteSmoke;
            dateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(88, 88);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(387, 27);
            dateTimePicker.TabIndex = 10;
            // 
            // labelBody
            // 
            labelBody.AutoSize = true;
            labelBody.Location = new Point(6, 268);
            labelBody.Name = "labelBody";
            labelBody.Size = new Size(44, 19);
            labelBody.TabIndex = 9;
            labelBody.Text = "Body";
            // 
            // labelAddressee
            // 
            labelAddressee.AutoSize = true;
            labelAddressee.Location = new Point(6, 210);
            labelAddressee.Name = "labelAddressee";
            labelAddressee.Size = new Size(80, 19);
            labelAddressee.TabIndex = 8;
            labelAddressee.Text = "Addressee";
            // 
            // labelSender
            // 
            labelSender.AutoSize = true;
            labelSender.Location = new Point(6, 152);
            labelSender.Name = "labelSender";
            labelSender.Size = new Size(57, 19);
            labelSender.TabIndex = 7;
            labelSender.Text = "Sender";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(6, 94);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(41, 19);
            labelDate.TabIndex = 6;
            labelDate.Text = "Date";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(6, 36);
            labelName.Name = "labelName";
            labelName.Size = new Size(49, 19);
            labelName.TabIndex = 5;
            labelName.Text = "Name";
            // 
            // bodyTextBox
            // 
            bodyTextBox.BackColor = Color.FromArgb(39, 49, 70);
            bodyTextBox.Location = new Point(88, 264);
            bodyTextBox.Multiline = true;
            bodyTextBox.Name = "bodyTextBox";
            bodyTextBox.Size = new Size(512, 252);
            bodyTextBox.TabIndex = 4;
            // 
            // confirmButton
            // 
            confirmButton.BackColor = Color.FromArgb(61, 165, 244);
            confirmButton.DialogResult = DialogResult.OK;
            confirmButton.Font = new Font("SF Pro Display", 12F, FontStyle.Regular, GraphicsUnit.Point);
            confirmButton.ForeColor = Color.WhiteSmoke;
            confirmButton.Location = new Point(490, 540);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(128, 45);
            confirmButton.TabIndex = 2;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = false;
            // 
            // draftButton
            // 
            draftButton.BackColor = Color.FromArgb(61, 165, 244);
            draftButton.DialogResult = DialogResult.Abort;
            draftButton.Font = new Font("SF Pro Display", 12F, FontStyle.Regular, GraphicsUnit.Point);
            draftButton.ForeColor = Color.WhiteSmoke;
            draftButton.Location = new Point(356, 540);
            draftButton.Name = "draftButton";
            draftButton.Size = new Size(128, 45);
            draftButton.TabIndex = 3;
            draftButton.Text = "Save as draft";
            draftButton.UseVisualStyleBackColor = false;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 49, 70);
            ClientSize = new Size(630, 597);
            Controls.Add(draftButton);
            Controls.Add(confirmButton);
            Controls.Add(groupBox);
            Name = "EditForm";
            Text = "MailForm";
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox;
        private Label labelBody;
        private Label labelAddressee;
        private Label labelSender;
        private Label labelDate;
        private Label labelName;
        private Button confirmButton;
        internal protected TextBox nameTextBox;
        internal protected TextBox bodyTextBox;
        internal protected ComboBox addresseeComboBox;
        internal protected ComboBox senderComboBox;
        internal protected DateTimePicker dateTimePicker;
        private Button draftButton;
    }
}