namespace Barroc_IT
{
    partial class ChangeProject
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
            this.ChangeProjectTitle = new System.Windows.Forms.Label();
            this.StartDatelbl = new System.Windows.Forms.Label();
            this.EndDatelbl = new System.Windows.Forms.Label();
            this.progressionlbl = new System.Windows.Forms.Label();
            this.Datetbx = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Closebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangeProjectTitle
            // 
            this.ChangeProjectTitle.AutoSize = true;
            this.ChangeProjectTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeProjectTitle.Location = new System.Drawing.Point(83, 9);
            this.ChangeProjectTitle.Name = "ChangeProjectTitle";
            this.ChangeProjectTitle.Size = new System.Drawing.Size(212, 33);
            this.ChangeProjectTitle.TabIndex = 1;
            this.ChangeProjectTitle.Text = "Change project";
            // 
            // StartDatelbl
            // 
            this.StartDatelbl.AutoSize = true;
            this.StartDatelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDatelbl.Location = new System.Drawing.Point(12, 57);
            this.StartDatelbl.Name = "StartDatelbl";
            this.StartDatelbl.Size = new System.Drawing.Size(80, 20);
            this.StartDatelbl.TabIndex = 2;
            this.StartDatelbl.Text = "Start date";
            // 
            // EndDatelbl
            // 
            this.EndDatelbl.AutoSize = true;
            this.EndDatelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDatelbl.Location = new System.Drawing.Point(13, 89);
            this.EndDatelbl.Name = "EndDatelbl";
            this.EndDatelbl.Size = new System.Drawing.Size(74, 20);
            this.EndDatelbl.TabIndex = 3;
            this.EndDatelbl.Text = "End date";
            // 
            // progressionlbl
            // 
            this.progressionlbl.AutoSize = true;
            this.progressionlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressionlbl.Location = new System.Drawing.Point(12, 119);
            this.progressionlbl.Name = "progressionlbl";
            this.progressionlbl.Size = new System.Drawing.Size(93, 20);
            this.progressionlbl.TabIndex = 4;
            this.progressionlbl.Text = "Progression";
            // 
            // Datetbx
            // 
            this.Datetbx.Location = new System.Drawing.Point(98, 58);
            this.Datetbx.Name = "Datetbx";
            this.Datetbx.Size = new System.Drawing.Size(278, 20);
            this.Datetbx.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(284, 20);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(111, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(265, 20);
            this.textBox2.TabIndex = 7;
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(17, 153);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(107, 39);
            this.Savebtn.TabIndex = 8;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // Closebtn
            // 
            this.Closebtn.Location = new System.Drawing.Point(269, 153);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(107, 39);
            this.Closebtn.TabIndex = 9;
            this.Closebtn.Text = "Close";
            this.Closebtn.UseVisualStyleBackColor = true;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // ChangeProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 204);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Datetbx);
            this.Controls.Add(this.progressionlbl);
            this.Controls.Add(this.EndDatelbl);
            this.Controls.Add(this.StartDatelbl);
            this.Controls.Add(this.ChangeProjectTitle);
            this.Name = "ChangeProject";
            this.Text = "ChangeProject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChangeProjectTitle;
        private System.Windows.Forms.Label StartDatelbl;
        private System.Windows.Forms.Label EndDatelbl;
        private System.Windows.Forms.Label progressionlbl;
        public System.Windows.Forms.TextBox Datetbx;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Button Closebtn;
    }
}