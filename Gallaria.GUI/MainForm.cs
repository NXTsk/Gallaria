using DataAccess.Model;
using Gallaria.ApiClient;
using Gallaria.ApiClient.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallaria.GUI
{
    public partial class MainForm : Form
    {
        public static AuthUserDto User;

        private Button _currentButton;
        private Color _themeColor = ColorTranslator.FromHtml("#34c5e6");
        private Color _selectedColor = ColorTranslator.FromHtml("#006e9c");
        private Form _displayCreatedArts;
        internal Form _activeForm;

        private PersonClient _personClient;

        public MainForm(AuthUserDto user)
        {
            InitializeComponent();
            User = user;
            _personClient = new PersonClient(Constants.APIUrl);

            var person = Task.Run(async () => await GetPersonByIdAsync(User.UserId)).ConfigureAwait(false).GetAwaiter().GetResult();

            lblUserName.Text = person.FirstName;

            this.WindowState = FormWindowState.Maximized;
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private async Task<PersonDto> GetPersonByIdAsync(int id)
        {
            PersonDto person = await _personClient.GetPersonByIdAsync(id);
            return person;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (_currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = _selectedColor;
                    _currentButton = (Button)btnSender;
                    _currentButton.BackColor = color;
                    _currentButton.ForeColor = Color.White;
                    _currentButton.Font = new System.Drawing.Font("Yu Gothic UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelSidebar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = _themeColor;
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (_activeForm != null)
                _activeForm.Close();
            ActivateButton(btnSender);
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DrawingTool(), sender);
        }

        private void BtnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (_activeForm != null)
                _activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Home";
            panelTitleBar.BackColor = _themeColor;
            _currentButton = null;
            btnCloseChildForm.Visible = false;
            _activeForm = _displayCreatedArts;
        }

        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UploadArtForm(), sender);
        }

        private void BtnEditArt_Click(object sender, EventArgs e)
        {
            _displayCreatedArts = new DisplayCreatedArts(this);
            OpenChildForm(_displayCreatedArts, sender);
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Dispose();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
    }
}
