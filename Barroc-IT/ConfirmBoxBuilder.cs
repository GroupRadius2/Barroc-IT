using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barroc_IT
{
    class ConfirmBoxBuilder
    {
        private ConfirmBox confirmBox;
        private Label labelTop;
        private RichTextBox richTextBoxCenter;

        public ConfirmBoxBuilder()
        {
            confirmBox = new ConfirmBox();
        }

        public ConfirmBoxBuilder(ConfirmBox confirmBox)
        {
            this.confirmBox = confirmBox;
        }

        public void BuildSize(int width, int height)
        {
            confirmBox.ConfirmForm.Width = width;
            confirmBox.ConfirmForm.Height = height;
        }

        public void BuildTop(string text)
        {
            labelTop = new Label();
            labelTop.Location = new Point(5, 5);
            labelTop.Text = text;

            confirmBox.ConfirmForm.Controls.Add(labelTop);
        }

        public void BuildCenter(string text)
        {
            richTextBoxCenter = new RichTextBox();
            richTextBoxCenter.Location = new Point(5, labelTop.Height + 5);
            richTextBoxCenter.Width = confirmBox.ConfirmForm.Width - 25;
            richTextBoxCenter.Height = confirmBox.ConfirmForm.Height - labelTop.Height - 150;

            richTextBoxCenter.Text = text;

            confirmBox.ConfirmForm.Controls.Add(richTextBoxCenter);
        }

        public void BuildBottom()
        {
            Button buttonAccept = new Button();
            Button buttonDecline = new Button();

            buttonAccept.Text = "Accept";
            buttonDecline.Text = "Decline";
            buttonAccept.Click += buttonAccept_Click;
            buttonDecline.Click += buttonDecline_Click;

            buttonAccept.Location = new Point(5, labelTop.Height + richTextBoxCenter.Height + 10);
            buttonDecline.Location = new Point(confirmBox.ConfirmForm.Width - 95, labelTop.Height + richTextBoxCenter.Height + 10);

            confirmBox.ConfirmForm.Controls.Add(buttonAccept);
            confirmBox.ConfirmForm.Controls.Add(buttonDecline);
        }

        private void buttonDecline_Click(object sender, EventArgs e)
        {
            confirmBox.Accept(false);
            confirmBox.ConfirmForm.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            confirmBox.Accept(true);
            Database.GetInstance().ExecuteQuery();
            confirmBox.ConfirmForm.Close();
        }

        public ConfirmBox GetConfirmBox()
        {
            return confirmBox;
        }
    }
}
