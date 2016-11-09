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
            this.Namelbl = new System.Windows.Forms.Label();
            this.Nametbx = new System.Windows.Forms.TextBox();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Closebtn = new System.Windows.Forms.Button();
            this.Timetbx = new System.Windows.Forms.TextBox();
            this.Datetbx = new System.Windows.Forms.TextBox();
            this.Timelbl = new System.Windows.Forms.Label();
            this.Datelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChangeAppointmentTitle
            // 
            this.ChangeAppointmentTitle.AutoSize = true;
            this.ChangeAppointmentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeAppointmentTitle.Location = new System.Drawing.Point(56, 9);
            this.ChangeAppointmentTitle.Name = "ChangeAppointmentTitle";
            this.ChangeAppointmentTitle.Size = new System.Drawing.Size(287, 33);
            this.ChangeAppointmentTitle.TabIndex = 0;
            this.ChangeAppointmentTitle.Text = "Change Appointment";
            // 
            // Namelbl
            // 
            this.Namelbl.AutoSize = true;
            this.Namelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Namelbl.Location = new System.Drawing.Point(15, 53);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(51, 20);
            this.Namelbl.TabIndex = 2;
            this.Namelbl.Text = "Name";
            // 
            // Nametbx
            // 
            this.Nametbx.Location = new System.Drawing.Point(64, 55);
            this.Nametbx.Name = "Nametbx";
            this.Nametbx.Size = new System.Drawing.Size(322, 20);
            this.Nametbx.TabIndex = 4;
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(19, 156);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(142, 39);
            this.Savebtn.TabIndex = 5;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // Closebtn
            // 
            this.Closebtn.Location = new System.Drawing.Point(244, 156);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(142, 39);
            this.Closebtn.TabIndex = 6;
            this.Closebtn.Text = "Close";
            this.Closebtn.UseVisualStyleBackColor = true;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // Timetbx
            // 
            this.Timetbx.Location = new System.Drawing.Point(64, 113);
            this.Timetbx.Name = "Timetbx";
            this.Timetbx.Size = new System.Drawing.Size(322, 20);
            this.Timetbx.TabIndex = 10;
            // 
            // Datetbx
            // 
            this.Datetbx.Location = new System.Drawing.Point(64, 81);
            this.Datetbx.Name = "Datetbx";
            this.Datetbx.Size = new System.Drawing.Size(322, 20);
            this.Datetbx.TabIndex = 9;
            // 
            // Timelbl
            // 
            this.Timelbl.AutoSize = true;
            this.Timelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timelbl.Location = new System.Drawing.Point(15, 111);
            this.Timelbl.Name = "Timelbl";
            this.Timelbl.Size = new System.Drawing.Size(43, 20);
            this.Timelbl.TabIndex = 8;
            this.Timelbl.Text = "Time";
            // 
            // Datelbl
            // 
            this.Datelbl.AutoSize = true;
            this.Datelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datelbl.Location = new System.Drawing.Point(15, 81);
            this.Datelbl.Name = "Datelbl";
            this.Datelbl.Size = new System.Drawing.Size(44, 20);
            this.Datelbl.TabIndex = 7;
            this.Datelbl.Text = "Date";
            // 
            // ChangeAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 203);
            this.Controls.Add(this.Timetbx);
            this.Controls.Add(this.Datetbx);
            this.Controls.Add(this.Timelbl);
            this.Controls.Add(this.Datelbl);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.Nametbx);
            this.Controls.Add(this.Namelbl);
            this.Controls.Add(this.ChangeAppointmentTitle);
            this.Name = "ChangeAppointment";
            this.Text = "ChangeAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChangeAppointmentTitle;
        private System.Windows.Forms.Label Namelbl;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Button Closebtn;
        public System.Windows.Forms.TextBox Nametbx;
        public System.Windows.Forms.TextBox Timetbx;
        public System.Windows.Forms.TextBox Datetbx;
        private System.Windows.Forms.Label Timelbl;
        private System.Windows.Forms.Label Datelbl;
    }
}