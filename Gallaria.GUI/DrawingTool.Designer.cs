
namespace Gallaria.GUI
{
    partial class DrawingTool
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStripUndoRedo = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripFill = new System.Windows.Forms.ToolStripButton();
            this.trackBarSize2 = new System.Windows.Forms.TrackBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBrush = new System.Windows.Forms.ToolStripButton();
            this.toolStripEraser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonColor = new System.Windows.Forms.ToolStripButton();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStripUndoRedo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize2)).BeginInit();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.toolStripUndoRedo);
            this.groupBox1.Controls.Add(this.trackBarSize2);
            this.groupBox1.Controls.Add(this.toolStrip);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(802, 51);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // toolStripUndoRedo
            // 
            this.toolStripUndoRedo.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStripUndoRedo.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripUndoRedo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripUndoRedo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonUndo,
            this.toolStripButtonRedo,
            this.toolStripFill});
            this.toolStripUndoRedo.Location = new System.Drawing.Point(280, 20);
            this.toolStripUndoRedo.Name = "toolStripUndoRedo";
            this.toolStripUndoRedo.Size = new System.Drawing.Size(100, 27);
            this.toolStripUndoRedo.TabIndex = 2;
            this.toolStripUndoRedo.Text = "toolStrip1";
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Image = global::Gallaria.GUI.Properties.Resources.undo_icon_1320085939108537891;
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonUndo.Text = "Undo";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.ToolStripButtonUndo_Click);
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRedo.Image = global::Gallaria.GUI.Properties.Resources.redo_icon_1320085938952280370;
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonRedo.Text = "Redo";
            this.toolStripButtonRedo.Click += new System.EventHandler(this.ToolStripButtonRedo_Click);
            // 
            // toolStripFill
            // 
            this.toolStripFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFill.Image = global::Gallaria.GUI.Properties.Resources.fillIcon_32x32;
            this.toolStripFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFill.Name = "toolStripFill";
            this.toolStripFill.Size = new System.Drawing.Size(29, 24);
            this.toolStripFill.Text = "toolStripButton1";
            this.toolStripFill.ToolTipText = "Fill";
            this.toolStripFill.Click += new System.EventHandler(this.ToolStripFill_Click);
            // 
            // trackBarSize2
            // 
            this.trackBarSize2.Location = new System.Drawing.Point(95, 11);
            this.trackBarSize2.Maximum = 30;
            this.trackBarSize2.Minimum = 2;
            this.trackBarSize2.Name = "trackBarSize2";
            this.trackBarSize2.Size = new System.Drawing.Size(182, 56);
            this.trackBarSize2.SmallChange = 2;
            this.trackBarSize2.TabIndex = 1;
            this.trackBarSize2.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarSize2.Value = 2;
            this.trackBarSize2.Scroll += new System.EventHandler(this.TrackBarSize_Scroll);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBrush,
            this.toolStripEraser,
            this.toolStripButtonColor});
            this.toolStrip.Location = new System.Drawing.Point(0, 20);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(802, 29);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripBrush
            // 
            this.toolStripBrush.AutoSize = false;
            this.toolStripBrush.AutoToolTip = false;
            this.toolStripBrush.Checked = true;
            this.toolStripBrush.CheckOnClick = true;
            this.toolStripBrush.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripBrush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBrush.Image = global::Gallaria.GUI.Properties.Resources.brush_128x128;
            this.toolStripBrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBrush.Name = "toolStripBrush";
            this.toolStripBrush.Size = new System.Drawing.Size(29, 24);
            this.toolStripBrush.Text = "Brush";
            this.toolStripBrush.ToolTipText = "Brush";
            this.toolStripBrush.Click += new System.EventHandler(this.ToolStripButton_Click);
            // 
            // toolStripEraser
            // 
            this.toolStripEraser.CheckOnClick = true;
            this.toolStripEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripEraser.Image = global::Gallaria.GUI.Properties.Resources.eraser_icon_125292;
            this.toolStripEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEraser.Name = "toolStripEraser";
            this.toolStripEraser.Size = new System.Drawing.Size(29, 26);
            this.toolStripEraser.Text = "Eraser";
            this.toolStripEraser.Click += new System.EventHandler(this.ToolStripButton_Click);
            // 
            // toolStripButtonColor
            // 
            this.toolStripButtonColor.AutoSize = false;
            this.toolStripButtonColor.BackColor = System.Drawing.Color.Black;
            this.toolStripButtonColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButtonColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonColor.Name = "toolStripButtonColor";
            this.toolStripButtonColor.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripButtonColor.Size = new System.Drawing.Size(29, 26);
            this.toolStripButtonColor.Click += new System.EventHandler(this.ToolStripButtonColor_Click);
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.SystemColors.Control;
            this.pbCanvas.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCanvas.Location = new System.Drawing.Point(0, 79);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(802, 424);
            this.pbCanvas.TabIndex = 6;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbCanvas_MouseDown);
            this.pbCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbCanvas_MouseMove);
            // 
            // DrawingTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 503);
            this.Controls.Add(this.pbCanvas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "DrawingTool";
            this.Text = "Create";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStripUndoRedo.ResumeLayout(false);
            this.toolStripUndoRedo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize2)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStripUndoRedo;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.ToolStripButton toolStripButtonRedo;
        private System.Windows.Forms.TrackBar trackBarSize2;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripBrush;
        private System.Windows.Forms.ToolStripButton toolStripEraser;
        private System.Windows.Forms.ToolStripButton toolStripButtonColor;
        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.ToolStripButton toolStripFill;
    }
}