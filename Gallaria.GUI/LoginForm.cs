using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Gallaria.ApiClient.ApiResponses;
using Gallaria.ApiClient;
using Gallaria.ApiClient.DTOs;

namespace Gallaria.GUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            CustomizeComponents();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimalize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void CustomizeComponents()
        {
            //setting size of textboxes
            txtUserName.AutoSize = false;
            txtUserName.Size = new Size(350, 40);

            txtPassword.AutoSize = false;
            txtPassword.Size = new Size(350, 40);
            txtPassword.UseSystemPasswordChar = true;
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
           await LoginUserAsync();
        }

        private async Task LoginUserAsync()
        {
            AuthenticatedUserData userData = await AuthenticateController.LoginAsync(new UserDto { Email = txtUserName.Text, Password = txtPassword.Text });

            if (userData.isUserAuthenticated)
            {
                this.Hide();
                MainForm mainForm = new MainForm(userData);
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(null, "Wrong username or password", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
