using Gallaria.ApiClient;
using Gallaria.ApiClient.DTOs;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallaria.GUI
{
    public partial class UpdateArtForm : Form
    {
        ArtClient artClient; 
        string newTitle;
        string newCategory;
        string newDescription;
        decimal newPrice;

        public ArtDto _artDto;

        public UpdateArtForm(ArtDto artDto)
        {
            InitializeComponent();
            _artDto = artDto;
            artClient = new ArtClient(Constants.APIUrl);

            Bitmap bmp;
            using (var ms = new MemoryStream(_artDto.Image))
            {
                bmp = new Bitmap(ms);
            }
            pictureBox.Image = bmp;

            textBoxPrice.Text = _artDto.Price.ToString();
            textBoxTitle.Text = _artDto.Title;
            richTextBoxDescription.Text = _artDto.Description;
            //TODO: Not working
            comboBoxCategory.SelectedItem = _artDto.Category;


        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            if(textBoxTitle.Text.Length > 0)
            {
                newTitle = textBoxTitle.Text;
            }
            if (!comboBoxCategory.Text.Equals("-select category-"))
            {
                newCategory = comboBoxCategory.Text;
            }
            if (textBoxPrice.Text.Length > 0)
            {
                Decimal.TryParse(textBoxPrice.Text, out newPrice);
            }
            if (richTextBoxDescription.Text != "")
            {
                newDescription = richTextBoxDescription.Text;
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

        private async void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                _artDto.Title = newTitle;
                _artDto.Description = newDescription;
                _artDto.Category = newCategory;
                _artDto.Price = newPrice;

                bool result = await artClient.UpdateArtAsync(_artDto);
                if (result == true)
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

        private void UpdateArtForm_Load(object sender, EventArgs e)
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

            return IsValid;
        }
    }
}
