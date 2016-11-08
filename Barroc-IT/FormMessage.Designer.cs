namespace Barroc_IT
{
    partial class FormMessage
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
            this.labelToDepartment = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.comboBoxDepartments = new System.Windows.Forms.ComboBox();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelToDepartment
            // 
            this.labelToDepartment.AutoSize = true;
            this.labelToDepartment.Location = new System.Drawing.Point(13, 13);
            this.labelToDepartment.Name = "labelToDepartment";
            this.labelToDepartment.Size = new System.Drawing.Size(26, 13);
            this.labelToDepartment.TabIndex = 0;
            this.labelToDepartment.Text = "To: ";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(13, 36);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(46, 13);
            this.labelSubject.TabIndex = 1;
            this.labelSubject.Text = "Subject:";
            // 
            // comboBoxDepartments
            // 
            this.comboBoxDepartments.FormattingEnabled = true;
            this.comboBoxDepartments.Items.AddRange(new object[] {
            "Finance",
            "Sales",
            "Development"});
            this.comboBoxDepartments.Location = new System.Drawing.Point(100, 10);
            this.comboBoxDepartments.Name = "comboBoxDepartments";
            this.comboBoxDepartments.Size = new System.Drawing.Size(172, 21);
            this.comboBoxDepartments.TabIndex = 2;
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(100, 36);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(172, 20);
            this.textBoxSubject.TabIndex = 3;
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.Location = new System.Drawing.Point(13, 66);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.Size = new System.Drawing.Size(259, 154);
            this.richTextBoxMessage.TabIndex = 4;
            this.richTextBoxMessage.Text = "";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(13, 226);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(197, 226);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.comboBoxDepartments);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelToDepartment);
            this.Name = "FormMessage";
            this.Text = "New Message";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelToDepartment;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.ComboBox comboBoxDepartments;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonCancel;
    }
}