using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barroc_IT
{
    class ConfirmBox
    {
        private bool isAccepted;
        private Form confirmForm;

        public ConfirmBox()
        {
            isAccepted = false;
            confirmForm = new Form();
        }

        public Form ConfirmForm
        {
            get
            {
                return ConfirmForm;
            }
            set
            {
                ConfirmForm = value;
            }
        }

        public void Accept(bool isAccept)
        {
            isAccepted = isAccept;
        }

        public bool IsAccepted()
        {
            return isAccepted;
        }

        public void Show()
        {
            confirmForm.Show();
        }
    }
}
