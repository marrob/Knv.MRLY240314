
namespace Knv.MRLY240314
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class StepViewItem
    {
        public string Name { get; set; }
        public string Measured { get; set; }
        public string Result { get; set; }
        public string LowLimit { get; set; }
        public string HighLimit { get; set; }
        

        [Browsable(false)]
        public StepItem StepItem { get; set; }
    }
}
