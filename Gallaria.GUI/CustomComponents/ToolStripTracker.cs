using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Gallaria.GUI.CustomComponents
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]

    public class ToolStripTracker : ToolStripControlHost
    {
        TrackBar tb;
        public ToolStripTracker() : base(new TrackBar())
        {
            tb = (TrackBar)this.Control;
        }


    } 
}
