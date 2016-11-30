using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locker
{
    //Form that is used to change password
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            InitializeMyControl();
        }

        private void InitializeMyControl()
        {
            // Set to no text.
            textBoxPW1.Text = "";
            textBoxPW2.Text = "";
            // The password character is an asterisk.
            textBoxPW1.PasswordChar = '*';
            textBoxPW2.PasswordChar = '*';
        }

        private void OK()
        {
            if (textBoxPW1.Text == textBoxPW2.Text)
            {
                Locker locker = new Locker();
                locker.changePassword(textBoxPW1.Text);
                Interface1 msg = myFormSettings.myForm1;
                msg.msg();
                this.Close();
            }
            else
            {
                messageLabel.Text = ("Passwords don't match, please rewrite them");
                textBoxPW1.Text = "";
                textBoxPW2.Text = "";
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            OK();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxPW1_KeyDown(object sender, KeyEventArgs e)
        {
            //user can press enter while textbox is active istead of pressing the button with mouse
            if (e.KeyCode == Keys.Enter)
            {
                OK();
            }
        }

        private void textBoxPW2_KeyDown(object sender, KeyEventArgs e)
        {
            //user can press enter while textbox is active istead of pressing the button with mouse
            if (e.KeyCode == Keys.Enter)
            {
                OK();
            }
        }
    }
}
