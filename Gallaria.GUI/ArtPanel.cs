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
        private ArtDto _artDto;
        private MainForm _mainForm;
        private DisplayCreatedArts _displayCreatedArts;

        public ArtPanel(ArtDto artDto, MainForm mainForm, DisplayCreatedArts displayCreatedArts)
        {
            InitializeComponent();
            _artDto = artDto;
            _mainForm = mainForm;
            _displayCreatedArts = displayCreatedArts;

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
            UpdateArtForm updateArtForm = new UpdateArtForm(_artDto, _displayCreatedArts);
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
