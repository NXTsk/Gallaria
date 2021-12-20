using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Gallaria.GUI
{
    public partial class DrawingTool : Form
    {
        public Point Current = new Point();
        public Point Old = new Point();
        public Pen P = new Pen(Color.Black, 5);
        public Pen Pe = new Pen(Color.White, 5);
        public Graphics G;

        private const int Height = 870; 
        private const int Width = 1160; 

        Bitmap _bitmap;
        Image _openedFile;

        private Stack<Bitmap> _undoStack;
        private Stack<Bitmap> _redoStack;


        public DrawingTool()
        {
            InitializeComponent();

            this._bitmap = new Bitmap(Width, Height);
            this._undoStack = new Stack<Bitmap>();
            this._redoStack = new Stack<Bitmap>();

            toolStripBrush.Checked = true;
            G = pbCanvas.CreateGraphics();

            //smoothing the drawing line
            P.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            Pe.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

            //Changing the background of saved picture to white
            ClearBitmap();
        }

        private void PbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            Old = e.Location;

            AddStep();
        }

        private void PbCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            G = Graphics.FromImage(_bitmap);
            if (e.Button == MouseButtons.Left && toolStripBrush.Checked)
            {
                Current = e.Location;
                G.DrawLine(P, Old, Current);
                Old = Current;
            }
            else if (e.Button == MouseButtons.Left && toolStripEraser.Checked)
            {
                Current = e.Location;
                G.DrawLine(Pe, Old, Current);
                Old = Current;
            }
            UpdateCanvas();
            
        }

        private void ButtonColorPicker_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                P.Color = cd.Color;
            }
        }


        private void TrackBarSize_Scroll(object sender, EventArgs e)
        {
            P.Width = trackBarSize2.Value;
            Pe.Width = trackBarSize2.Value;
        }

        private void ToolStripButton_Click(object sender, EventArgs e)
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

        private void ToolStripButtonColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                P.Color = cd.Color;
                toolStripButtonColor.BackColor = cd.Color;
            }
        }

        private void ToolStripButtonUndo_Click(object sender, EventArgs e)
        {
            if(_undoStack.Count >= 1)
            {
                Bitmap bitmap = UndoStep();
                UseStep(bitmap);
                UpdateCanvas();
            }
        }

        private void ToolStripButtonRedo_Click(object sender, EventArgs e)
        {
            if(_redoStack.Count >= 1)
            {
                Bitmap bitmap = RedoStep();
                UseStep(bitmap);
                UpdateCanvas();
            }
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
            op.Filter = "Image Files| *.jpg; *.jpeg; *.png|All files(*.*)|*.*";
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                _openedFile = Image.FromFile(op.FileName);
                _bitmap = new Bitmap(_openedFile);
                pbCanvas.ImageLocation = op.FileName;
                pbCanvas.Image = _bitmap;
            }
        }

        private void AddStep()
        {
            this._undoStack.Push(new Bitmap(this._bitmap));
        }

        private Bitmap UndoStep()
        {
            // return bitmap
            Bitmap returnMap = this._undoStack.Pop();

            this._redoStack.Push(this._bitmap);

            return returnMap;
        }

        private Bitmap RedoStep()
        {
            // return bitmap
            Bitmap returnMap = this._redoStack.Pop();

            this._undoStack.Push(this._bitmap);

            return returnMap;
        }

        private void UseStep(Bitmap bitmap)
        {
            this._bitmap = bitmap;
        }

        private void ClearBitmap()
        {
            for (int i = 0; i < _bitmap.Width; i++)
            {
                for (int j = 0; j < _bitmap.Height; j++)
                {
                    this._bitmap.SetPixel(i, j, Color.White);
                }
            }
        }

        private void UpdateCanvas()
        {
            pbCanvas.Image = _bitmap;
        }

        private void ToolStripFill_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _bitmap.Width; i++)
            {
                for (int j = 0; j < _bitmap.Height; j++)
                {
                    this._bitmap.SetPixel(i, j, P.Color);
                }
            }
        }
    }
}
