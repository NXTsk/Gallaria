
namespace Gallaria.GUI
{
    partial class UploadArtForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfPieces = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.btnPublish = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.errorProviderDataValidation = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblCharacterCounter = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDataValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(429, 43);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 20);
            this.lblFileName.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(156)))));
            this.btnSelectFile.FlatAppearance.BorderSize = 0;
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFile.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSelectFile.ForeColor = System.Drawing.Color.White;
            this.btnSelectFile.Location = new System.Drawing.Point(657, 39);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(110, 29);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.BtnSelectFile_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxTitle.Location = new System.Drawing.Point(429, 79);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.PlaceholderText = "Title*";
            this.textBoxTitle.Size = new System.Drawing.Size(338, 27);
            this.textBoxTitle.TabIndex = 2;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrice.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPrice.Location = new System.Drawing.Point(429, 194);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.PlaceholderText = "Price*";
            this.textBoxPrice.Size = new System.Drawing.Size(338, 27);
            this.textBoxPrice.TabIndex = 2;
            this.textBoxPrice.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            this.textBoxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPrice_KeyPress);
            // 
            // textBoxNumberOfPieces
            // 
            this.textBoxNumberOfPieces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNumberOfPieces.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNumberOfPieces.Location = new System.Drawing.Point(429, 156);
            this.textBoxNumberOfPieces.Name = "textBoxNumberOfPieces";
            this.textBoxNumberOfPieces.PlaceholderText = "Number of pieces*";
            this.textBoxNumberOfPieces.Size = new System.Drawing.Size(338, 27);
            this.textBoxNumberOfPieces.TabIndex = 2;
            this.textBoxNumberOfPieces.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            this.textBoxNumberOfPieces.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumberOfPieces_KeyPress);
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(429, 117);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(338, 28);
            this.comboBoxCategory.TabIndex = 3;
            this.comboBoxCategory.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            // 
            // btnPublish
            // 
            this.btnPublish.AllowDrop = true;
            this.btnPublish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPublish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(156)))));
            this.btnPublish.FlatAppearance.BorderSize = 0;
            this.btnPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublish.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPublish.ForeColor = System.Drawing.Color.White;
            this.btnPublish.Location = new System.Drawing.Point(267, 387);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(322, 52);
            this.btnPublish.TabIndex = 1;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = false;
            this.btnPublish.Click += new System.EventHandler(this.BtnPublish_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox.Image = global::Gallaria.GUI.Properties.Resources.uploadIcon512px;
            this.pictureBox.ImageLocation = "";
            this.pictureBox.Location = new System.Drawing.Point(28, 39);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(362, 271);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDescription.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxDescription.Location = new System.Drawing.Point(429, 247);
            this.richTextBoxDescription.MaxLength = 500;
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(338, 65);
            this.richTextBoxDescription.TabIndex = 5;
            this.richTextBoxDescription.Text = "";
            this.richTextBoxDescription.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            // 
            // errorProviderDataValidation
            // 
            this.errorProviderDataValidation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderDataValidation.ContainerControl = this;
            // 
            // lblCharacterCounter
            // 
            this.lblCharacterCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharacterCounter.AutoSize = true;
            this.lblCharacterCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblCharacterCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCharacterCounter.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCharacterCounter.Location = new System.Drawing.Point(704, 315);
            this.lblCharacterCounter.Name = "lblCharacterCounter";
            this.lblCharacterCounter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCharacterCounter.Size = new System.Drawing.Size(63, 20);
            this.lblCharacterCounter.TabIndex = 6;
            this.lblCharacterCounter.Text = "500/500";
            this.lblCharacterCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(427, 226);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(85, 20);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description";
            // 
            // UploadArtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 503);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCharacterCounter);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.textBoxNumberOfPieces);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.lblFileName);
            this.Name = "UploadArtForm";
            this.Text = "Upload Art";
            this.Load += new System.EventHandler(this.UploadArtForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDataValidation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxNumberOfPieces;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.ErrorProvider errorProviderDataValidation;
        private System.Windows.Forms.Label lblCharacterCounter;
        private System.Windows.Forms.Label lblDescription;
    }
}