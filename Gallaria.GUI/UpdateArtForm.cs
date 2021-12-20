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
        ArtClient _artClient; 
        string _newTitle;
        string _newCategory;
        string _newDescription;
        decimal _newPrice;

        private ArtDto _artDto;
        private DisplayCreatedArts _displayCreatedArts;

        public UpdateArtForm(ArtDto artDto, DisplayCreatedArts displayCreatedArts)
        {
            InitializeComponent();
            _artDto = artDto;
            _displayCreatedArts = displayCreatedArts;

            _artClient = new ArtClient(Constants.APIUrl);

            Bitmap bmp;
            using (var ms = new MemoryStream(_artDto.Image))
            {
                bmp = new Bitmap(ms);
            }

            pictureBox.Image = bmp;
            textBoxPrice.Text = _artDto.Price.ToString();
            textBoxTitle.Text = _artDto.Title;
            richTextBoxDescription.Text = _artDto.Description;
            comboBoxCategory.SelectedItem = _artDto.Category;


            _displayCreatedArts.Close();
        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            if(textBoxTitle.Text.Length > 0)
            {
                _newTitle = textBoxTitle.Text;
            }
            if (!comboBoxCategory.Text.Equals("-select category-"))
            {
                _newCategory = comboBoxCategory.Text;
            }
            if (textBoxPrice.Text.Length > 0)
            {
                Decimal.TryParse(textBoxPrice.Text, out _newPrice);
            }
            if (richTextBoxDescription.Text != "")
            {
                lblCharacterCounter.Text = $"{richTextBoxDescription.Text.Length}/500";
                _newDescription = richTextBoxDescription.Text;
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
                _artDto.Title = _newTitle;
                _artDto.Description = _newDescription;
                _artDto.Category = _newCategory;
                _artDto.Price = _newPrice;

                bool result = await _artClient.UpdateArtAsync(_artDto); 
                if (result == true)
                {
                    MessageBox.Show("Art was successfully updated", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Art couldn't be updated, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill all required fields.", "Gallaria - Message!");
            }
        }

        private void UpdateArtForm_Load(object sender, EventArgs e)
        {
            lblCharacterCounter.Text = $"{richTextBoxDescription.Text.Length}/500";
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
            if (string.IsNullOrEmpty(textBoxPrice.Text.Trim()))
            {
                errorProviderDataValidation.SetError(textBoxPrice, "field required!");
                IsValid = false;
            }

            return IsValid;
        }
    }
}
