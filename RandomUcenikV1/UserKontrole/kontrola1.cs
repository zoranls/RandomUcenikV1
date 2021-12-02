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

        string[] nizUCENICI;
        //  

        int brojUcenika = 0;
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

        private void listBox1_Click_1(object sender, EventArgs e)
        {

        }
         
        int korak =368;
        private void timer1_Tick(object sender, EventArgs e)
        {
            while (korak>1)
            {
                korak -= 1;
                panel1.Top = korak;
            }
             
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true; 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        
        }

        private void groupBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.Red;
        }
    }
}
/*
  TODO:Napravi da svki ucenik ide samo jednom u svakom krugu
  TODO:Duznici
  */
