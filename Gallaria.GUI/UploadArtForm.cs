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
        byte[] pictureBytes;
        ArtClient artClient; 
        string name;
        string category;
        int numberOfPieces;
        decimal price;
        string description;

        public UploadArtForm()
        {
            InitializeComponent();
            artClient = new ArtClient(Constants.APIUrl);

        }
        private async void BtnSelectFile_Click(object sender, System.EventArgs e)
        {
            //TODO: move this code to API Client

            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image Files|*.jpg;*.jpeg;*.png|All files(*.*)|*.*";
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                chosenPicture = Image.FromFile(op.FileName);
                lblFileName.Text = op.FileName;
                Bitmap img = new Bitmap(chosenPicture);

                using (var stream = new MemoryStream())
                {
                    img.Save(stream, chosenPicture.RawFormat);
                    pictureBox.Image = img;
                    pictureBytes = stream.ToArray();
                }
            }
        }
        public ArtDto CreateArtFromData()
        {
            ArtDto newArt = new ArtDto() {Title = name, AvailableQuantity = numberOfPieces, Category = category,CreationDate = DateTime.Now, Description = description, Price = price, Image = pictureBytes};
            return newArt;
        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            if(textBoxTitle.Text.Length > 0)
            {
                name = textBoxTitle.Text;
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
                lblCharacterCounter.Text = $"{richTextBoxDescription.Text.Length}/500";
                description = richTextBoxDescription.Text;
            }
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

                int result = await artClient.CreateArtAsync(art);
                if (result != -1)
                {
                    MessageBox.Show("Art was successfully uploaded", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Art couldn't be uploaded, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            lblCharacterCounter.Text = $"{richTextBoxDescription.Text.Length}/500";
            comboBoxCategory.DataSource = InputCategories();
        }

        private bool ValidateChildren()
        {
            bool IsValid = true;
            // Clear error provider only once.
            errorProviderDataValidation.Clear();

            //use if condition for every condtion, dont use else-if
            if (string.IsNullOrEmpty(textBoxTitle.Text.Trim()))
            {
                errorProviderDataValidation.SetError(textBoxTitle, "field required!");
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
            if (pictureBytes == null)
            {
                errorProviderDataValidation.SetError(btnSelectFile, "Select a picture!");
                IsValid = false;
            }

            return IsValid;
        }
    }
}
