﻿namespace Barroc_IT
{
    partial class NewAppointment
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
            this.label1 = new System.Windows.Forms.Label();
            this.Datelbl = new System.Windows.Forms.Label();
            this.Timelbl = new System.Windows.Forms.Label();
            this.Datetbx = new System.Windows.Forms.TextBox();
            this.Timetbx = new System.Windows.Forms.TextBox();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Closebtn = new System.Windows.Forms.Button();
            this.Projecttbx = new System.Windows.Forms.TextBox();
            this.Projectlbl = new System.Windows.Forms.Label();
            this.Namelbl = new System.Windows.Forms.Label();
            this.Nametbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "New appointment";
            // 
            // Datelbl
            // 
            this.Datelbl.AutoSize = true;
            this.Datelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datelbl.Location = new System.Drawing.Point(18, 86);
            this.Datelbl.Name = "Datelbl";
            this.Datelbl.Size = new System.Drawing.Size(44, 20);
            this.Datelbl.TabIndex = 1;
            this.Datelbl.Text = "Date";
            // 
            // Timelbl
            // 
            this.Timelbl.AutoSize = true;
            this.Timelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timelbl.Location = new System.Drawing.Point(19, 114);
            this.Timelbl.Name = "Timelbl";
            this.Timelbl.Size = new System.Drawing.Size(43, 20);
            this.Timelbl.TabIndex = 2;
            this.Timelbl.Text = "Time";
            // 
            // Datetbx
            // 
            this.Datetbx.Location = new System.Drawing.Point(68, 86);
            this.Datetbx.Name = "Datetbx";
            this.Datetbx.Size = new System.Drawing.Size(278, 20);
            this.Datetbx.TabIndex = 3;
            // 
            // Timetbx
            // 
            this.Timetbx.Location = new System.Drawing.Point(68, 116);
            this.Timetbx.Name = "Timetbx";
            this.Timetbx.Size = new System.Drawing.Size(278, 20);
            this.Timetbx.TabIndex = 4;
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(12, 183);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(94, 42);
            this.Savebtn.TabIndex = 7;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Closebtn
            // 
            this.Closebtn.Location = new System.Drawing.Point(252, 183);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(94, 42);
            this.Closebtn.TabIndex = 8;
            this.Closebtn.Text = "Close";
            this.Closebtn.UseVisualStyleBackColor = true;
            this.Closebtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Projecttbx
            // 
            this.Projecttbx.Location = new System.Drawing.Point(104, 142);
            this.Projecttbx.Name = "Projecttbx";
            this.Projecttbx.Size = new System.Drawing.Size(242, 20);
            this.Projecttbx.TabIndex = 9;
            // 
            // Projectlbl
            // 
            this.Projectlbl.AutoSize = true;
            this.Projectlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Projectlbl.Location = new System.Drawing.Point(19, 142);
            this.Projectlbl.Name = "Projectlbl";
            this.Projectlbl.Size = new System.Drawing.Size(79, 20);
            this.Projectlbl.TabIndex = 10;
            this.Projectlbl.Text = "Project ID";
            // 
            // Namelbl
            // 
            this.Namelbl.AutoSize = true;
            this.Namelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Namelbl.Location = new System.Drawing.Point(19, 58);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(51, 20);
            this.Namelbl.TabIndex = 11;
            this.Namelbl.Text = "Name";
            // 
            // Nametbx
            // 
            this.Nametbx.Location = new System.Drawing.Point(68, 59);
            this.Nametbx.Name = "Nametbx";
            this.Nametbx.Size = new System.Drawing.Size(278, 20);
            this.Nametbx.TabIndex = 12;
            // 
            // NewAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 233);
            this.Controls.Add(this.Nametbx);
            this.Controls.Add(this.Namelbl);
            this.Controls.Add(this.Projectlbl);
            this.Controls.Add(this.Projecttbx);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.Timetbx);
            this.Controls.Add(this.Datetbx);
            this.Controls.Add(this.Timelbl);
            this.Controls.Add(this.Datelbl);
            this.Controls.Add(this.label1);
            this.Name = "NewAppointment";
            this.Text = "NewAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Datelbl;
        private System.Windows.Forms.Label Timelbl;
        private System.Windows.Forms.TextBox Datetbx;
        private System.Windows.Forms.TextBox Timetbx;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.TextBox Projecttbx;
        private System.Windows.Forms.Label Projectlbl;
        private System.Windows.Forms.Label Namelbl;
        private System.Windows.Forms.TextBox Nametbx;
    }
}