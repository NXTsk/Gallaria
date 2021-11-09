﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallaria.GUI
{
    public partial class DrawingTool : Form
    {
        public Point current = new Point();
        public Point old = new Point();
        public Pen p = new Pen(Color.Black, 5);
        public Pen pe = new Pen(Color.White, 5);
        public Graphics g;

        Bitmap bitmap = new Bitmap(1700, 820);
        Image openedFile;




        public DrawingTool()
        {
            InitializeComponent();
            toolStripBrush.Checked = true;
            g = pbCanvas.CreateGraphics();

            //smoothing the drawing line
            p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            pe.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

            //Changing the background of saved picture to white
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i, j, Color.White);
                }
            }
        }

        private void PbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            old = e.Location;
        }

        private void PbCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            g = Graphics.FromImage(bitmap);
            if (e.Button == MouseButtons.Left && toolStripBrush.Checked)
            {
                current = e.Location;
                g.DrawLine(p, old, current);
                old = current;
            }
            else if (e.Button == MouseButtons.Left && toolStripEraser.Checked)
            {
                current = e.Location;
                g.DrawLine(pe, old, current);
                old = current;
            }
            pbCanvas.Image = bitmap;
        }

        private void buttonColorPicker_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                p.Color = cd.Color;
            }
        }


        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            p.Width = trackBarSize2.Value;
            pe.Width = trackBarSize2.Value;
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton item in ((ToolStripButton)sender).GetCurrentParent().Items)
            {
                if (item == sender) item.Checked = true;
                if ((item != null) && (item != sender))
                {
                    item.Checked = false;
                }
            }
        }

        private void toolStripButtonColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                p.Color = cd.Color;
                toolStripButtonColor.BackColor = cd.Color;
            }
        }

        private void toolStripButtonUndo_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
        {

        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Jpeg Image|*.jpg|Bitmap Image *.bmp|";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        this.pbCanvas.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pbCanvas.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }
                fs.Close();
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                openedFile = Image.FromFile(op.FileName);
                bitmap = new Bitmap(openedFile);
                pbCanvas.ImageLocation = op.FileName;
                pbCanvas.Image = bitmap;
            }
        }
    }
}