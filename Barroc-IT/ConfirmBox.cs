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
        private bool isChosen;
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
                return confirmForm;
            }
            set
            {
                confirmForm = value;
            }
        }

        public void Accept(bool isAccept)
        {
            isAccepted = isAccept;
            isChosen = true;
        }

        public bool IsAccepted()
        {
            return isAccepted;
        }

        public bool IsChosen()
        {
            return isChosen;
        }

        public void Show()
        {
            confirmForm.Show();
        }
    }
}
