
namespace Gallaria.GUI
{
    partial class LoginForm
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
            this.titleBar = new System.Windows.Forms.Panel();
            this.btnMinimalize = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.checkBoxRememberPassword = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkLabelForgotPassword = new System.Windows.Forms.LinkLabel();
            this.lblGallaria = new System.Windows.Forms.Label();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimalize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.titleBar.Controls.Add(this.btnMinimalize);
            this.titleBar.Controls.Add(this.btnClose);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(450, 44);
            this.titleBar.TabIndex = 0;
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            // 
            // btnMinimalize
            // 
            this.btnMinimalize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimalize.Image = global::Gallaria.GUI.Properties.Resources.minimize_32x32;
            this.btnMinimalize.Location = new System.Drawing.Point(368, 5);
            this.btnMinimalize.Name = "btnMinimalize";
            this.btnMinimalize.Size = new System.Drawing.Size(32, 32);
            this.btnMinimalize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMinimalize.TabIndex = 2;
            this.btnMinimalize.TabStop = false;
            this.btnMinimalize.Click += new System.EventHandler(this.BtnMinimalize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::Gallaria.GUI.Properties.Resources.crossIcon_32x32;
            this.btnClose.Location = new System.Drawing.Point(406, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 688);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(450, 15);
            this.bottomPanel.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.ForeColor = System.Drawing.Color.Black;
            this.lblUserName.Location = new System.Drawing.Point(43, 235);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(117, 31);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Username";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserName.Location = new System.Drawing.Point(50, 269);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(350, 34);
            this.txtUserName.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(50, 352);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(350, 31);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.Location = new System.Drawing.Point(43, 318);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(111, 31);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // checkBoxRememberPassword
            // 
            this.checkBoxRememberPassword.AutoSize = true;
            this.checkBoxRememberPassword.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxRememberPassword.Location = new System.Drawing.Point(50, 395);
            this.checkBoxRememberPassword.Name = "checkBoxRememberPassword";
            this.checkBoxRememberPassword.Size = new System.Drawing.Size(171, 24);
            this.checkBoxRememberPassword.TabIndex = 6;
            this.checkBoxRememberPassword.Text = "Remember password";
            this.checkBoxRememberPassword.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(50, 486);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(350, 50);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // linkLabelForgotPassword
            // 
            this.linkLabelForgotPassword.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.linkLabelForgotPassword.AutoSize = true;
            this.linkLabelForgotPassword.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelForgotPassword.LinkColor = System.Drawing.Color.Black;
            this.linkLabelForgotPassword.Location = new System.Drawing.Point(150, 643);
            this.linkLabelForgotPassword.Name = "linkLabelForgotPassword";
            this.linkLabelForgotPassword.Size = new System.Drawing.Size(148, 23);
            this.linkLabelForgotPassword.TabIndex = 8;
            this.linkLabelForgotPassword.TabStop = true;
            this.linkLabelForgotPassword.Text = "Forgot password ?";
            // 
            // lblGallaria
            // 
            this.lblGallaria.AutoSize = true;
            this.lblGallaria.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGallaria.ForeColor = System.Drawing.Color.White;
            this.lblGallaria.Location = new System.Drawing.Point(112, 105);
            this.lblGallaria.Name = "lblGallaria";
            this.lblGallaria.Size = new System.Drawing.Size(240, 81);
            this.lblGallaria.TabIndex = 9;
            this.lblGallaria.Text = "Gallaria";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(197)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(450, 703);
            this.Controls.Add(this.lblGallaria);
            this.Controls.Add(this.linkLabelForgotPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.checkBoxRememberPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.titleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log-in";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseMove);
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimalize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.PictureBox btnMinimalize;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox checkBoxRememberPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkLabelForgotPassword;
        private System.Windows.Forms.Label lblGallaria;
    }
}