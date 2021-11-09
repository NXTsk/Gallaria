
using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sidebar = new System.Windows.Forms.SplitContainer();
            this.panelDrawingCanvas = new System.Windows.Forms.Panel();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStripUndoRedo = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.trackBarSize2 = new System.Windows.Forms.TrackBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBrush = new System.Windows.Forms.ToolStripButton();
            this.toolStripEraser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonColor = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.sidebar)).BeginInit();
            this.sidebar.Panel2.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.panelDrawingCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStripUndoRedo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize2)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebar
            // 
            this.sidebar.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            // 
            // sidebar.Panel1
            // 
            this.sidebar.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            // 
            // sidebar.Panel2
            // 
            this.sidebar.Panel2.Controls.Add(this.panelDrawingCanvas);
            this.sidebar.Size = new System.Drawing.Size(800, 450);
            this.sidebar.SplitterDistance = 157;
            this.sidebar.TabIndex = 0;
            // 
            // panelDrawingCanvas
            // 
            this.panelDrawingCanvas.BackColor = System.Drawing.Color.White;
            this.panelDrawingCanvas.Controls.Add(this.pbCanvas);
            this.panelDrawingCanvas.Controls.Add(this.groupBox1);
            this.panelDrawingCanvas.Controls.Add(this.menuStrip1);
            this.panelDrawingCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panelDrawingCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDrawingCanvas.Location = new System.Drawing.Point(0, 0);
            this.panelDrawingCanvas.Name = "panelDrawingCanvas";
            this.panelDrawingCanvas.Size = new System.Drawing.Size(639, 450);
            this.panelDrawingCanvas.TabIndex = 0;
            this.panelDrawingCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbCanvas_MouseDown);
            this.panelDrawingCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbCanvas_MouseMove);
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.SystemColors.Control;
            this.pbCanvas.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCanvas.Location = new System.Drawing.Point(0, 82);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(639, 368);
            this.pbCanvas.TabIndex = 4;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbCanvas_MouseDown);
            this.pbCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbCanvas_MouseMove);
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
            this.groupBox1.Size = new System.Drawing.Size(639, 54);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // toolStripUndoRedo
            // 
            this.toolStripUndoRedo.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStripUndoRedo.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripUndoRedo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripUndoRedo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonUndo,
            this.toolStripButtonRedo});
            this.toolStripUndoRedo.Location = new System.Drawing.Point(378, 22);
            this.toolStripUndoRedo.Name = "toolStripUndoRedo";
            this.toolStripUndoRedo.Size = new System.Drawing.Size(71, 27);
            this.toolStripUndoRedo.TabIndex = 2;
            this.toolStripUndoRedo.Text = "toolStrip1";
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUndo.Image")));
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonUndo.Text = "Undo";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.toolStripButtonUndo_Click);
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRedo.Image")));
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonRedo.Text = "Redo";
            this.toolStripButtonRedo.Click += new System.EventHandler(this.toolStripButtonRedo_Click);
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
            this.trackBarSize2.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
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
            this.toolStrip.Size = new System.Drawing.Size(639, 29);
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
            this.toolStripBrush.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBrush.Image")));
            this.toolStripBrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBrush.Name = "toolStripBrush";
            this.toolStripBrush.Size = new System.Drawing.Size(29, 24);
            this.toolStripBrush.Text = "Brush";
            this.toolStripBrush.ToolTipText = "Brush";
            this.toolStripBrush.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripEraser
            // 
            this.toolStripEraser.CheckOnClick = true;
            this.toolStripEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripEraser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEraser.Image")));
            this.toolStripEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEraser.Name = "toolStripEraser";
            this.toolStripEraser.Size = new System.Drawing.Size(29, 26);
            this.toolStripEraser.Text = "Eraser";
            this.toolStripEraser.Click += new System.EventHandler(this.toolStripButton_Click);
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
            this.toolStripButtonColor.Click += new System.EventHandler(this.toolStripButtonColor_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sidebar);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.sidebar.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sidebar)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.panelDrawingCanvas.ResumeLayout(false);
            this.panelDrawingCanvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStripUndoRedo.ResumeLayout(false);
            this.toolStripUndoRedo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize2)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sidebar;
        private System.Windows.Forms.Panel panelDrawingCanvas;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripBrush;
        private System.Windows.Forms.ToolStripButton toolStripEraser;
        private System.Windows.Forms.ToolStripButton toolStripButtonColor;
        private TrackBar trackBarSize2;
        private GroupBox groupBox1;
        private ToolStrip toolStripUndoRedo;
        private ToolStripButton toolStripButtonUndo;
        private ToolStripButton toolStripButtonRedo;
        private PictureBox pbCanvas;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
    }
}

