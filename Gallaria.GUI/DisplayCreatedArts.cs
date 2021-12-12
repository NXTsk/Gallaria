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

            IEnumerable<ArtDto> artDtos = Task.Run(async () => await GetAllArtsThatByAuthorIdAsync(MainForm._user.UserId)).ConfigureAwait(false).GetAwaiter().GetResult();
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            foreach (ArtDto artDto in artDtos)
            {
                ArtPanel artPanel = new ArtPanel(artDto, mainForm, this) ;
                artPanel.Show();
                artPanel.BringToFront();
                this.Controls.Add(flowLayoutPanel);
                flowLayoutPanel.Dock = DockStyle.Fill;
                flowLayoutPanel.AutoScroll = true;
                flowLayoutPanel.BringToFront();
                flowLayoutPanel.Controls.Add(artPanel);
            }
        }

        private async Task<IEnumerable<ArtDto>> GetAllArtsThatByAuthorIdAsync(int authorId)
        {
            IEnumerable<ArtDto> artDtos = await artClient.GetAllArtsThatByAuthorIdAsync(authorId);
            return artDtos;
        }
    }
}
