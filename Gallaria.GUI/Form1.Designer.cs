
namespace Gallaria.GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.trackBarSize = new System.Windows.Forms.TrackBar();
            this.buttonColorPicker = new System.Windows.Forms.Button();
            this.radioButtonSelect = new System.Windows.Forms.RadioButton();
            this.radioButtonEraser = new System.Windows.Forms.RadioButton();
            this.radioButtonBrush = new System.Windows.Forms.RadioButton();
            this.panelDrawingCanvas = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelDrawingCanvas);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.trackBarSize);
            this.splitContainer2.Panel2.Controls.Add(this.buttonColorPicker);
            this.splitContainer2.Panel2.Controls.Add(this.radioButtonSelect);
            this.splitContainer2.Panel2.Controls.Add(this.radioButtonEraser);
            this.splitContainer2.Panel2.Controls.Add(this.radioButtonBrush);
            this.splitContainer2.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer2.Size = new System.Drawing.Size(266, 450);
            this.splitContainer2.SplitterDistance = 123;
            this.splitContainer2.TabIndex = 0;
            // 
            // trackBarSize
            // 
            this.trackBarSize.Location = new System.Drawing.Point(3, 89);
            this.trackBarSize.Maximum = 20;
            this.trackBarSize.Minimum = 2;
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.Size = new System.Drawing.Size(130, 56);
            this.trackBarSize.TabIndex = 4;
            this.trackBarSize.Value = 2;
            this.trackBarSize.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
            // 
            // buttonColorPicker
            // 
            this.buttonColorPicker.Location = new System.Drawing.Point(6, 188);
            this.buttonColorPicker.Name = "buttonColorPicker";
            this.buttonColorPicker.Size = new System.Drawing.Size(94, 29);
            this.buttonColorPicker.TabIndex = 3;
            this.buttonColorPicker.Text = "Color";
            this.buttonColorPicker.UseVisualStyleBackColor = true;
            this.buttonColorPicker.Click += new System.EventHandler(this.buttonColorPicker_Click);
            // 
            // radioButtonSelect
            // 
            this.radioButtonSelect.AutoSize = true;
            this.radioButtonSelect.Location = new System.Drawing.Point(3, 151);
            this.radioButtonSelect.Name = "radioButtonSelect";
            this.radioButtonSelect.Size = new System.Drawing.Size(70, 24);
            this.radioButtonSelect.TabIndex = 0;
            this.radioButtonSelect.Text = "Select";
            this.radioButtonSelect.UseVisualStyleBackColor = true;
            // 
            // radioButtonEraser
            // 
            this.radioButtonEraser.AutoSize = true;
            this.radioButtonEraser.Location = new System.Drawing.Point(3, 59);
            this.radioButtonEraser.Name = "radioButtonEraser";
            this.radioButtonEraser.Size = new System.Drawing.Size(70, 24);
            this.radioButtonEraser.TabIndex = 0;
            this.radioButtonEraser.Text = "Eraser";
            this.radioButtonEraser.UseVisualStyleBackColor = true;
            // 
            // radioButtonBrush
            // 
            this.radioButtonBrush.AutoSize = true;
            this.radioButtonBrush.Location = new System.Drawing.Point(3, 29);
            this.radioButtonBrush.Name = "radioButtonBrush";
            this.radioButtonBrush.Size = new System.Drawing.Size(66, 24);
            this.radioButtonBrush.TabIndex = 0;
            this.radioButtonBrush.Text = "Brush";
            this.radioButtonBrush.UseVisualStyleBackColor = true;
            // 
            // panelDrawingCanvas
            // 
            this.panelDrawingCanvas.BackColor = System.Drawing.Color.White;
            this.panelDrawingCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panelDrawingCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDrawingCanvas.Location = new System.Drawing.Point(0, 0);
            this.panelDrawingCanvas.Name = "panelDrawingCanvas";
            this.panelDrawingCanvas.Size = new System.Drawing.Size(530, 450);
            this.panelDrawingCanvas.TabIndex = 0;
            this.panelDrawingCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDrawingCanvas_MouseDown);
            this.panelDrawingCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDrawingCanvas_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RadioButton radioButtonSelect;
        private System.Windows.Forms.RadioButton radioButtonEraser;
        private System.Windows.Forms.RadioButton radioButtonBrush;
        private System.Windows.Forms.Panel panelDrawingCanvas;
        private System.Windows.Forms.Button buttonColorPicker;
        private System.Windows.Forms.TrackBar trackBarSize;
    }
}

