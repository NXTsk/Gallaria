using Gallaria.ApiClient.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallaria.GUI
{
    public partial class ArtPanel : UserControl
    {
        public ArtDto _artDto;
        public static MainForm _mainForm;

        public ArtPanel(ArtDto artDto, MainForm mainForm)
        {
            InitializeComponent();
            _artDto = artDto;
            _mainForm = mainForm;

            Bitmap bmp;
            using (var ms = new MemoryStream(artDto.Image))
            {
                bmp = new Bitmap(ms);
            }
            pictureBox.Image = bmp;

            lblArtTitle.Text = artDto.Title;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            UpdateArtForm updateArtForm = new UpdateArtForm(_artDto);
            updateArtForm.TopLevel = false;
            _mainForm.activeForm = updateArtForm;
            _mainForm.Controls.Add(updateArtForm);
            updateArtForm.BringToFront();
            updateArtForm.FormBorderStyle = FormBorderStyle.None;
            updateArtForm.Dock = DockStyle.Fill;
            updateArtForm.Show();
        }
    }
}
