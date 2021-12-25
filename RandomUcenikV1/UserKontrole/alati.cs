using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RandomUcenikV1.UserKontrole
{
    public partial class alati : UserControl
    {
        public alati()
        {
            InitializeComponent();
        }
        string path1;
        int brojUcenika;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> spisakUcenika = new List<string>();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    path1 = Path.GetFullPath("11.txt");
                    break;
                case 1:
                    path1 = Path.GetFullPath("12.txt");
                    break;
                case 2:
                    path1 = Path.GetFullPath("13.txt");
                    break;
                case 3:
                    path1 = Path.GetFullPath("21.txt");
                    break;
                case 4:
                    path1 = Path.GetFullPath("22.txt");
                    break;
                case 5:
                    path1 = Path.GetFullPath("23.txt");
                    break;
            }
            StreamReader citac = new StreamReader(path1);
            while (!citac.EndOfStream)
            {
                string a = citac.ReadLine();
                brojUcenika++;
            }
            citac.Close();
            StreamReader citac2 = new StreamReader(path1);
            string s = citac2.ReadLine();
           
            citac2.Close();
        }
    }
}
