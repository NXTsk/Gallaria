using Gallaria.ApiClient;
using Gallaria.ApiClient.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallaria.GUI
{
    public partial class DisplayCreatedArts : Form
    {
        private ArtClient artClient;
        public  DisplayCreatedArts(MainForm mainForm)
        {
            artClient = new ArtClient(Constants.APIUrl);
            InitializeComponent();

            ArtDto artDto = Task.Run(async () => await GetArtByIDAsync(207)).ConfigureAwait(false).GetAwaiter().GetResult();

            ArtPanel artPanel = new ArtPanel(artDto, mainForm);
            artPanel.Show();
            artPanel.BringToFront();
            this.Controls.Add(artPanel);
        }

        private async Task<ArtDto> GetArtByIDAsync(int id)
        {
            ArtDto artDto = await artClient.GetArtByIDAsync(id);
            return artDto;
        }
    }
}
