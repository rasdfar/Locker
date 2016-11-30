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
    //Form that pops up when user is about to "uninstal"
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            String warning = "Caution!\n\n" +
                "You are about to delete hidden files this program uses, your locker folder and all the content inside.\n\n" +
                "After running this option you are only left with Locker.exe so you can move it to different directory if you wish\n\n" +
                "If you want to stop using this program it's safe to delete the exe file after you have ran this option.\n\n";
            String boldWarning = "Are you sure you want to continue, all your content inside Locker folder is about to be deleted?";
            warningLabel.Text = warning;
            BoldWarningLabel.Text = boldWarning;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Locker locker = new Locker();
            locker.deleteLockerFiles();
            Interface1 close = myFormSettings.myForm1;
            close.close();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
