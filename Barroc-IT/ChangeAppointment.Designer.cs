namespace Barroc_IT
{
    partial class ChangeAppointment
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
            this.ChangeAppointmentTitle = new System.Windows.Forms.Label();
            this.DateLbl = new System.Windows.Forms.Label();
            this.TimeLbl = new System.Windows.Forms.Label();
            this.Datetbx = new System.Windows.Forms.TextBox();
            this.TimeTbx = new System.Windows.Forms.TextBox();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Closebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangeAppointmentTitle
            // 
            this.ChangeAppointmentTitle.AutoSize = true;
            this.ChangeAppointmentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeAppointmentTitle.Location = new System.Drawing.Point(44, 14);
            this.ChangeAppointmentTitle.Name = "ChangeAppointmentTitle";
            this.ChangeAppointmentTitle.Size = new System.Drawing.Size(287, 33);
            this.ChangeAppointmentTitle.TabIndex = 0;
            this.ChangeAppointmentTitle.Text = "Change Appointment";
            // 
            // DateLbl
            // 
            this.DateLbl.AutoSize = true;
            this.DateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLbl.Location = new System.Drawing.Point(21, 78);
            this.DateLbl.Name = "DateLbl";
            this.DateLbl.Size = new System.Drawing.Size(44, 20);
            this.DateLbl.TabIndex = 1;
            this.DateLbl.Text = "Date";
            // 
            // TimeLbl
            // 
            this.TimeLbl.AutoSize = true;
            this.TimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLbl.Location = new System.Drawing.Point(21, 108);
            this.TimeLbl.Name = "TimeLbl";
            this.TimeLbl.Size = new System.Drawing.Size(43, 20);
            this.TimeLbl.TabIndex = 2;
            this.TimeLbl.Text = "Time";
            // 
            // Datetbx
            // 
            this.Datetbx.Location = new System.Drawing.Point(70, 78);
            this.Datetbx.Name = "Datetbx";
            this.Datetbx.Size = new System.Drawing.Size(287, 20);
            this.Datetbx.TabIndex = 3;
            // 
            // TimeTbx
            // 
            this.TimeTbx.Location = new System.Drawing.Point(70, 110);
            this.TimeTbx.Name = "TimeTbx";
            this.TimeTbx.Size = new System.Drawing.Size(287, 20);
            this.TimeTbx.TabIndex = 4;
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(25, 156);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(107, 39);
            this.Savebtn.TabIndex = 5;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // Closebtn
            // 
            this.Closebtn.Location = new System.Drawing.Point(250, 156);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(107, 39);
            this.Closebtn.TabIndex = 6;
            this.Closebtn.Text = "Close";
            this.Closebtn.UseVisualStyleBackColor = true;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // ChangeAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 207);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.TimeTbx);
            this.Controls.Add(this.Datetbx);
            this.Controls.Add(this.TimeLbl);
            this.Controls.Add(this.DateLbl);
            this.Controls.Add(this.ChangeAppointmentTitle);
            this.Name = "ChangeAppointment";
            this.Text = "ChangeAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChangeAppointmentTitle;
        private System.Windows.Forms.Label DateLbl;
        private System.Windows.Forms.Label TimeLbl;
        private System.Windows.Forms.TextBox TimeTbx;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Button Closebtn;
        public System.Windows.Forms.TextBox Datetbx;
    }
}