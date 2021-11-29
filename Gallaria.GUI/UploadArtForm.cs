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
        Image chosenPicture;
        string pictureBase64String;
        ArtController artController = new ArtController();
        string name;
        string category;
        int numberOfPieces;
        decimal price;
        string description;

        public UploadArtForm()
        {
            InitializeComponent();
           
        }
        private async void BtnSelectFile_Click(object sender, System.EventArgs e)
        {
            //TODO: move this code to API Client

            OpenFileDialog op = new OpenFileDialog();
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                chosenPicture = Image.FromFile(op.FileName);
                lblFileName.Text = op.FileName;
                Bitmap img = new Bitmap(chosenPicture);
                using (var stream = new MemoryStream())
                {
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    pictureBox.Image = img;
                    byte[] byteArray = stream.ToArray();
                    pictureBase64String = Convert.ToBase64String(byteArray);
                }
            }
        }
        public ArtDto CreateArtFromData()
        {
            ArtDto newArt = new ArtDto() {Title = name, AvailableQuantity = numberOfPieces, Category = category,CreationDate = DateTime.Now, Description = description, Price = price, Image = pictureBase64String};
            return newArt;
        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            if(textBoxName.Text.Length > 0)
            {
                name = textBoxName.Text;
            }
            if (!comboBoxCategory.Text.Equals("-select category-"))
            {
                category = comboBoxCategory.Text;
            }

            if (textBoxNumberOfPieces.Text.Length > 0)
            {
                int.TryParse(textBoxNumberOfPieces.Text, out numberOfPieces);
            }
            if (textBoxPrice.Text.Length > 0)
            {
                Decimal.TryParse(textBoxPrice.Text, out price);
            }
            if (richTextBoxDescription.Text != "")
            {
                description = richTextBoxDescription.Text;
            }
        }

        private void RichTextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            lblCharacterCounter.Text = $"{richTextBoxDescription.Text.Length}/500";

        }

        private void TextBoxNumberOfPieces_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private async void BtnPublish_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                ArtDto art = CreateArtFromData();
                art.AuthorId = MainForm._user.UserId;

                var result = await ArtController.CreateArtAsync(art);
                if (result.hasBeenCreated)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill all required fields.", "Gallaria - Message!");
            }

            
        }

        public string[] InputCategories()
        {
            var categories = new[] {"-select category-","Abstract", "Photography", "Portrait", "Landscape", "Nature", "Animals", "Pixel art", "Surrealism"};
            Array.Sort(categories, (x, y) => String.Compare(x, y));
            return categories;
        }

        private void UploadArtForm_Load(object sender, EventArgs e)
        {
            comboBoxCategory.SelectedItem = null;
            comboBoxCategory.SelectedText = "--select--";
            lblCharacterCounter.Text = $"{richTextBoxDescription.Text.Length}/500";
            comboBoxCategory.DataSource = InputCategories();
        }

        private bool ValidateChildren()
        {
            bool IsValid = true;
            // Clear error provider only once.
            errorProviderDataValidation.Clear();

            //use if condition for every condtion, dont use else-if
            if (string.IsNullOrEmpty(textBoxName.Text.Trim()))
            {
                errorProviderDataValidation.SetError(textBoxName, "field required!");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(comboBoxCategory.Text.Trim()) || comboBoxCategory.Text == "-select category-")
            {
                errorProviderDataValidation.SetError(comboBoxCategory, "field required!");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(textBoxNumberOfPieces.Text.Trim()))
            {
                errorProviderDataValidation.SetError(textBoxNumberOfPieces, "field required!");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text.Trim()))
            {
                errorProviderDataValidation.SetError(textBoxPrice, "field required!");
                IsValid = false;
            }
            if (pictureBase64String == null)
            {
                errorProviderDataValidation.SetError(btnSelectFile, "Select a picture!");
                IsValid = false;
            }

            return IsValid;
        }
    }
}
