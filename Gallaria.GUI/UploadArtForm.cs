using Gallaria.ApiClient;
using Gallaria.ApiClient.DTOs;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallaria.GUI
{
    public partial class UploadArtForm : Form
    {
        Image openedFile;
        ArtController artController = new ArtController();

        public UploadArtForm()
        {
            InitializeComponent();

        }
        private async void btnSelectFile_Click(object sender, System.EventArgs e)
        {
            ////TODO: move this code to API Client

            //OpenFileDialog op = new OpenFileDialog();
            //DialogResult dr = op.ShowDialog();
            //if (dr == DialogResult.OK)
            //{
            //    openedFile = Image.FromFile(op.FileName);
            //    Bitmap img = new Bitmap(openedFile);
            //    using (var stream = new MemoryStream())
            //    {
            //        img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            //        byte[] byteArray = stream.ToArray();
            //    }
            //}
            DisplayArtAsync(5);

        }
        private async void DisplayArtAsync(int id)
        {
            Bitmap bmpReturn = null;

            ArtDto art = await ArtController.GetArtByIDAsync(5);
            byte[] byteBuffer = Convert.FromBase64String(art.Image);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);
            memoryStream.Position = 0;


            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);


            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            pictureBox.Image = bmpReturn;

        }
    }
}
