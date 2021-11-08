using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gallaria_DC.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ToolButton_Click(object sender, RoutedEventArgs e)
        {
            // Get a reference to the radiobutton
            var radiobutton = sender as RadioButton;

            // Get the radiobutton pressed
            string radioBPressed = radiobutton.Content.ToString();

            // Change settings based on button
            if (radioBPressed == "Brush")
            {
                this.drawingCanvas.EditingMode = InkCanvasEditingMode.Ink;
            }
            else if (radioBPressed == "Eraser")
            {
                this.drawingCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }
            else if (radioBPressed == "Select")
            {
                this.drawingCanvas.EditingMode = InkCanvasEditingMode.Select;
            }
        }

        private void BrushSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ////Get Slider reference
            //var slider = sender as Slider;
            ////Get Slider value
            //double value = slider.Value;
            ////Change brush size
            //strokeAttribute.Width = value;
            ////drawingCanvas.DefaultDrawingAttributes.Height = value;
            //////strokeAttribute.Height = value;
        }

        //private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        //{
        //    TextBox.Text = "#" + ClrPcker_Background.SelectedColor.R.ToString() + ClrPcker_Background.SelectedColor.G.ToString() + ClrPcker_Background.SelectedColor.B.ToString();
        //}
    }
}
