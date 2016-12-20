namespace Locker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.lockButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordRequiredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLockerFilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChestImg = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChestImg)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(3, 16);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(385, 20);
            this.textBoxPassword.TabIndex = 0;
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.passwordLabel);
            this.flowLayoutPanel1.Controls.Add(this.textBoxPassword);
            this.flowLayoutPanel1.Controls.Add(this.lockButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(391, 70);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(3, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Password:";
            // 
            // lockButton
            // 
            this.lockButton.Location = new System.Drawing.Point(3, 42);
            this.lockButton.Name = "lockButton";
            this.lockButton.Size = new System.Drawing.Size(75, 23);
            this.lockButton.TabIndex = 2;
            this.lockButton.Text = "Lock";
            this.lockButton.UseVisualStyleBackColor = true;
            this.lockButton.Click += new System.EventHandler(this.lockButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(9, 100);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(146, 13);
            this.messageLabel.TabIndex = 2;
            this.messageLabel.Text = "Wellcome to use Locker app!";
            this.messageLabel.Click += new System.EventHandler(this.messageLabel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(419, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.passwordRequiredToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // passwordRequiredToolStripMenuItem
            // 
            this.passwordRequiredToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem1,
            this.deleteLockerFilesToolStripMenuItem1});
            this.passwordRequiredToolStripMenuItem.Name = "passwordRequiredToolStripMenuItem";
            this.passwordRequiredToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.passwordRequiredToolStripMenuItem.Text = "Password required";
            // 
            // changePasswordToolStripMenuItem1
            // 
            this.changePasswordToolStripMenuItem1.Name = "changePasswordToolStripMenuItem1";
            this.changePasswordToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.changePasswordToolStripMenuItem1.Text = "Change Password";
            this.changePasswordToolStripMenuItem1.Click += new System.EventHandler(this.changePasswordToolStripMenuItem1_Click);
            // 
            // deleteLockerFilesToolStripMenuItem1
            // 
            this.deleteLockerFilesToolStripMenuItem1.Name = "deleteLockerFilesToolStripMenuItem1";
            this.deleteLockerFilesToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.deleteLockerFilesToolStripMenuItem1.Text = "Delete Locker Files";
            this.deleteLockerFilesToolStripMenuItem1.Click += new System.EventHandler(this.deleteLockerFilesToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ChestImg
            // 
            this.ChestImg.Location = new System.Drawing.Point(355, 69);
            this.ChestImg.Name = "ChestImg";
            this.ChestImg.Size = new System.Drawing.Size(52, 51);
            this.ChestImg.TabIndex = 4;
            this.ChestImg.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 132);
            this.Controls.Add(this.ChestImg);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Locker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChestImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button lockButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordRequiredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteLockerFilesToolStripMenuItem1;
        private System.Windows.Forms.PictureBox ChestImg;
    }
}

