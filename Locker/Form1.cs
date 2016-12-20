using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Locker;
using System.Reflection;
using System.IO;
using System.Diagnostics;
/*
Relese 12.10.2015
version 0.2*

App made to make locking and hiding folders easy.
With easy password change option to make it secure and
easy to use for the user.
Offers reasonable amount of security.
It's easy to remove when you deside to not use it anymore
you can find uninstall option from the top menu.
You don't have to worry about leaving unwanted hidden folders
or files this way.


-Jani Kärkkäinen
*since change to C#
*/
/*
To do:

-CRYPT THE LOCKER CONTENTS 
    Guite urgent since it's security feature.
    Maiby make own class from it if it's large feature to make.
    But make it optional function since it may cause some data loss.
    and not every user simply need it.

-ReWrite the code on C++ so exe cannot be reflected from the exe file(http://stackoverflow.com/questions/2659513/how-to-get-source-code-of-a-windows-executable)
    Better sooner than laiter.
    Security issue!

-Change password.txt into Settings/data/appData.txt or smtg like that.

-Use better crypt method than base64 with password
    Too weak easy to open.
    Something that uses its own keyword in crypting and use it only inside C++ code.
    Or generate random seed into password.txt file and use it with cryption:
        -seed: "random"
        -password: "(password*(mystery funktion)^seed)"
    PGP?(https://en.wikipedia.org/wiki/Pretty_Good_Privacy)

-User interface quality of live
    Maiby make own installation slider show when app is first time opened.
    Better images and icons.
    Default grey style is kinda dull.

-Online update option and new class for it.
    Not really urgent feature but would be usefull learning.
    Thread needed?

-Change about text:
    Change version into variable so you dont forget to change it everytime.
    Tell user not to rename locker folder.
    There is text about readmefile in it, that is no longer used.

-Language options
    Not urgent

-Open first time-> choose PW (and language)
    Quality of live change

*/
namespace Locker
{
    //Main form that program uses
    public partial class Form1 : Form , Interface1
    {
        Locker locker = null; //empty locker object
        String givenPassword; //empty password string
        bool unlock;          //empty bool that tells if password was correct or not

        private void setPicture()
        {
            //Changes picture on the corner depending on folder status
            String caseSwitch = locker.status();
            switch(caseSwitch)
            {
                case "Lock":
                    ChestImg.Image = Properties.Resources.Open;
                    break;
                case "Unlock":
                    ChestImg.Image = Properties.Resources.Close;
                    break;
            }
            ChestImg.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void lockUnlock()
        {
            //if button text Lock locker.lockFolder()
            //if button text Unlock locker.unlock()
            //password needed
            //set msglabel
            String caseSwitch = lockButton.Text;
            switch (caseSwitch)
            {
                case "Lock":
                    givenPassword = textBoxPassword.Text;
                    unlock = locker.getPassword(givenPassword);
                    if (unlock)
                    {
                        locker.lockFolder();
                        messageLabel.Text = "Folder locked";
                        lockButton.Text = locker.status();
                        setPicture();
                        textBoxPassword.Text = "";
                    }
                    else
                    {
                        messageLabel.Text = "Wrong password!";
                        textBoxPassword.Text = "";
                    }
                    break;

                case "Unlock":
                    givenPassword = textBoxPassword.Text;
                    unlock = locker.getPassword(givenPassword);
                    if (unlock)
                    {
                        messageLabel.ForeColor = System.Drawing.Color.Blue;
                        String path = locker.getPath();
                        messageLabel.Text = "Folder unlocked at " + path; //Shows path to unlocked folder
                        locker.unlockFolder();
                        lockButton.Text = locker.status();
                        setPicture();
                        textBoxPassword.Text = "";
                    }
                    else
                    {
                        messageLabel.Text = "Wrong password!";
                        textBoxPassword.Text = "";
                    }
                    break;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeMyControl()
        {
            //Make textbox into a password wield
            //All the characters entered by user are represented as "*"
            textBoxPassword.Text = "";
            textBoxPassword.PasswordChar = '*';
        }

        private void lockButton_Click(object sender, EventArgs e)
        {
            lockUnlock();
        }

        private void passwordButton_Click(object sender, EventArgs e)
        {
            givenPassword = textBoxPassword.Text;
            unlock = locker.getPassword(givenPassword);
            if(unlock)
            {
                Form2 changePW = new Form2();
                changePW.Show();
                textBoxPassword.Text = "";
            }
            else
            {
                messageLabel.Text = "You need to enter the current password in order to change it";
                textBoxPassword.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            locker = new Locker();
            lockButton.Text = locker.status();
            InitializeMyControl();
            myFormSettings.myForm1 = this;
            setPicture();
            //if dir name = Locker ->lockbutton text = Lock
            //if dir name = contropanell... -> lockbutton text = Unlock
        }

        void Interface1.msg()
        {
            messageLabel.Text = "Pasword was changed";
        }

        void Interface1.close()
        {
            this.Close();
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            givenPassword = textBoxPassword.Text;
            unlock = locker.getPassword(givenPassword);
            if (unlock)
            {
                Form2 changePW = new Form2();
                changePW.Show();
                textBoxPassword.Text = "";
            }
            else
            {
                messageLabel.Text = "You need to enter the current password inorder to change it";
                textBoxPassword.Text = "";
            }
        }

        private void deleteLockerFilesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            givenPassword = textBoxPassword.Text;
            unlock = locker.getPassword(givenPassword);
            if (unlock)
            {
                Form3 warning = new Form3();
                warning.Show();
                textBoxPassword.Text = "";
            }
            else
            {
                messageLabel.Text = "You need to enter the current password to delete all locker files";
                textBoxPassword.Text = "";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(locker.aboutText);
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //user can press enter while textbox is active istead of pressing the button with mouse
            if (e.KeyCode == Keys.Enter)
            {
                lockUnlock();
            }
        }

        private void messageLabel_Click(object sender, EventArgs e)
        {
            String path = locker.getPath();
            if (messageLabel.Text == "Folder unlocked at " + path)
            {
                Process.Start(@path);
            }
        }
    }
}
