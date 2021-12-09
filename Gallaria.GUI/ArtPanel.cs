﻿using Gallaria.ApiClient.DTOs;
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
        public ArtPanel(ArtDto artDto)
        {
            InitializeComponent();

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
        }
    }
}
