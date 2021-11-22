using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gallaria.GUI
{
    public partial class UploadArtForm : Form
    {
        Image openedFile;

        public UploadArtForm()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, System.EventArgs e)
        {
            //TODO: move this code to API Client

            OpenFileDialog op = new OpenFileDialog();
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                openedFile = Image.FromFile(op.FileName);
                Bitmap img = new Bitmap(openedFile);
                using (var stream = new MemoryStream())
                {
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteArray = stream.ToArray();
                }
            } 
        }
    }
}
