using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomUcenikV1
{
    public partial class webSajt : UserControl
    {
        public webSajt()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }
         
    }
}
