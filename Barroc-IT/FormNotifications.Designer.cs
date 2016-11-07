namespace Barroc_IT
{
    partial class FormNotifications
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
            this.dataGridViewAllNotifications = new System.Windows.Forms.DataGridView();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.labelNotifications = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllNotifications)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAllNotifications
            // 
            this.dataGridViewAllNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllNotifications.Location = new System.Drawing.Point(12, 29);
            this.dataGridViewAllNotifications.Name = "dataGridViewAllNotifications";
            this.dataGridViewAllNotifications.Size = new System.Drawing.Size(142, 220);
            this.dataGridViewAllNotifications.TabIndex = 0;
            this.dataGridViewAllNotifications.SelectionChanged += new System.EventHandler(this.dataGridViewAllNotifications_SelectionChanged);
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.Location = new System.Drawing.Point(160, 29);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.ReadOnly = true;
            this.richTextBoxMessage.Size = new System.Drawing.Size(259, 220);
            this.richTextBoxMessage.TabIndex = 1;
            this.richTextBoxMessage.Text = "";
            // 
            // labelNotifications
            // 
            this.labelNotifications.AutoSize = true;
            this.labelNotifications.Location = new System.Drawing.Point(13, 13);
            this.labelNotifications.Name = "labelNotifications";
            this.labelNotifications.Size = new System.Drawing.Size(65, 13);
            this.labelNotifications.TabIndex = 2;
            this.labelNotifications.Text = "Notifications";
            // 
            // FormNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 261);
            this.Controls.Add(this.labelNotifications);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.dataGridViewAllNotifications);
            this.Name = "FormNotifications";
            this.Text = "Notifications";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllNotifications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAllNotifications;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.Label labelNotifications;
    }
}