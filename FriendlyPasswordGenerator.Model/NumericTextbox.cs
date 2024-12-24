using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FriendlyPasswordGenerator.Model
{
    public partial class NumericTextbox : TextBox
    {
        public NumericTextbox()
        {
            InitializeComponent();
        }

        protected override void OnKeyPress()
        {
            base.OnKeyPress();

            if (e.KeyData is 
                Keys.Control or Keys.ControlKey
                or Keys.Shift or Keys.ShiftKey
                or Keys.Alt or Keys.Menu)
            {
                return;
            }

            if (e.KeyData is Keys.Left or Keys.Right or Keys.Up or Keys.Down)
            {
                return;
            }

            char c = e.KeyChar;

            if (!char.IsControl(c) && !char.IsDigit(c))
            {
                this.ShowWarningToolTip("Somente números são permitidos!");
                e.Handled = true;
            }
            e.Handled = true;
        }
    }
}
