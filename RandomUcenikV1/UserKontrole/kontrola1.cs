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

namespace RandomUcenikV1
{
    public partial class kontrola1 : UserControl
    {
        public kontrola1()
        {
            InitializeComponent();
        }

        //public void
        variable1 var = new variable1();
        string path1;
        Random rand = new Random();
        string[] nizPROVERADUPL;
        bool proveraStanja = false;
        string[] nizUCENICI;
        //  

        int brojUcenika = 0;

        struct Pozicije
        {
            public int x;
            public int y;
        }

        Pozicije PozicijePanela1 = new Pozicije();
        //BELEZENJE U NIZ IZ STREAMREADER
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

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
            }
            StreamReader citac = new StreamReader(path1);
            while (!citac.EndOfStream)
            {
                string a = citac.ReadLine();
                brojUcenika++;
            }
            nizUCENICI = new string[brojUcenika];
            nizPROVERADUPL = new string[brojUcenika];
            citac.Close();
            StreamReader citac2 = new StreamReader(path1);
            string s = citac2.ReadLine();
            for (int i = 0; i < brojUcenika; i++)
            {
                nizUCENICI[i] = s;
                s = citac2.ReadLine();

            }
            citac2.Close();

        }
        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_//

        //UZIMANJE IMENA IZ NIZA

        bool MetodaProveravanja(string Unos)
        {
            bool a = true;
            for (int i = 0; i < brojUcenika; i++)
            {
                if (nizPROVERADUPL[i] == Unos)
                {
                    a = false;
                }
            }
            return a;
        }
        //----//
        int broj = 0;
        string temp2;

        void RandomFunkcija()
        {
            broj = rand.Next(0, brojUcenika);
            temp2 = nizUCENICI[broj];

        }
        //------//
        int temp1 = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            RandomFunkcija();
            switch (MetodaProveravanja(temp2))
            {
                case false:
                    RandomFunkcija();
                    break;
                case true:
                    nizPROVERADUPL[temp1] = nizUCENICI[broj];

                    label1.Text = nizUCENICI[broj];
                    listBox1.Items.Add(nizUCENICI[broj]);
                    temp1++;
                    break;
                    { }
            }
        }
        //=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+//
        string[] f = new string[7];
        private void button2_Click_1(object sender, EventArgs e)
        {
            string[] noviNiz = f;
            int a = listBox2.SelectedIndex;
            for (int i = a; i < noviNiz.Length - 1; i++)
            {
                noviNiz[i] = noviNiz[i + 1];

            }
            StreamWriter OverWrite = new StreamWriter(@"C:\Users\Zoki\source\repos\WindowsFormsApp1\WindowsFormsApp1\BazePodataka\TextFile1.txt");
            int c = 0;
            while (c < noviNiz.Length)
            {
                OverWrite.WriteLine(noviNiz[c]);
                c++;
            }
            OverWrite.Close();
        }
        //=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+//

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PozicijePanela1.x = panel2.Location.X;
            PozicijePanela1.y = panel2.Location.Y;

            proveraStanja = true;
            switch (proveraStanja)
            {
                case true:
                    panel2.Location = new Point(PozicijePanela1.x, PozicijePanela1.y -= 90);

                    proveraStanja = false;
                    break;
                case false:

                    break;
            }
        }

        bool provera = true;
        private void groupBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            int a = groupBox1.Location.Y;
            switch (provera)
            {
                case true:
                    groupBox1.Location = new Point(groupBox1.Location.X, a -= 25);
                    provera = false;
                    break;
                case false:
                    groupBox1.Location = new Point(groupBox1.Location.X, a += 25);
                    provera = true;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
/*
  TODO:Napravi da svki ucenik ide samo jednom u svakom krugu
  TODO:Duznici
  */
