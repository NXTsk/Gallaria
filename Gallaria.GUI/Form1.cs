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
    public partial class Form1 : Form
    {
        public Point current = new Point();
        public Point old = new Point();
        public Pen p = new Pen(Color.Black, 5);
        public Pen pe = new Pen(Color.White, 5);
        public Graphics g;


        public Form1()
        {
            InitializeComponent();
            radioButtonBrush.Checked = true;
            g = panelDrawingCanvas.CreateGraphics();
            //smoothing the drawing line
            p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            pe.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
        }

        private void panelDrawingCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            old = e.Location;
        }

        private void panelDrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && radioButtonBrush.Checked)
            {
                current = e.Location;
                g.DrawLine(p, old, current);
                old = current;
            } else if (e.Button == MouseButtons.Left && radioButtonEraser.Checked)
            {
                current = e.Location;
                g.DrawLine(pe, old, current);
                old = current;
            }
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
            p.Width = trackBarSize.Value;
            pe.Width = trackBarSize.Value;
        }


    }
}
