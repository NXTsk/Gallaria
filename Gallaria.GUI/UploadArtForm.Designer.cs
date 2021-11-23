
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfPieces = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.btnPublish = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.errorProviderDataValidation = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.lblFileName.Size = new System.Drawing.Size(97, 20);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "FileName.jpg";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(156)))));
            this.btnSelectFile.FlatAppearance.BorderSize = 0;
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFile.ForeColor = System.Drawing.Color.White;
            this.btnSelectFile.Location = new System.Drawing.Point(657, 39);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(110, 29);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(429, 80);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(338, 27);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.Text = "Name";
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrice.Location = new System.Drawing.Point(429, 198);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(338, 27);
            this.textBoxPrice.TabIndex = 2;
            this.textBoxPrice.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            this.textBoxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrice_KeyPress);
            // 
            // textBoxNumberOfPieces
            // 
            this.textBoxNumberOfPieces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNumberOfPieces.Location = new System.Drawing.Point(429, 159);
            this.textBoxNumberOfPieces.Name = "textBoxNumberOfPieces";
            this.textBoxNumberOfPieces.Size = new System.Drawing.Size(338, 27);
            this.textBoxNumberOfPieces.TabIndex = 2;
            this.textBoxNumberOfPieces.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            this.textBoxNumberOfPieces.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumberOfPieces_KeyPress);
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(429, 119);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(338, 28);
            this.comboBoxCategory.TabIndex = 3;
            this.comboBoxCategory.Text = "Category";
            this.comboBoxCategory.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // btnPublish
            // 
            this.btnPublish.AllowDrop = true;
            this.btnPublish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPublish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(156)))));
            this.btnPublish.FlatAppearance.BorderSize = 0;
            this.btnPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublish.ForeColor = System.Drawing.Color.White;
            this.btnPublish.Location = new System.Drawing.Point(267, 387);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(322, 52);
            this.btnPublish.TabIndex = 1;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = false;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox.Image = global::Gallaria.GUI.Properties.Resources.upload_icon_64x64;
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
            this.richTextBoxDescription.Location = new System.Drawing.Point(429, 237);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(338, 75);
            this.richTextBoxDescription.TabIndex = 5;
            this.richTextBoxDescription.Text = "Description";
            this.richTextBoxDescription.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // errorProviderDataValidation
            // 
            this.errorProviderDataValidation.ContainerControl = this;
            // 
            // UploadArtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 503);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.textBoxNumberOfPieces);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.lblFileName);
            this.Name = "UploadArtForm";
            this.Text = "Upload Art";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDataValidation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxNumberOfPieces;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.ErrorProvider errorProviderDataValidation;
    }
}