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
            try
            {

                RandomFunkcija();
                switch (MetodaProveravanja(temp2))
                {
                    case false:
                        RandomFunkcija();
                        break;
                    case true:
                        nizPROVERADUPL[temp1] = nizUCENICI[broj]; 
                        listBox1.Items.Add(nizUCENICI[broj]);
                        temp1++;
                        break;
                        { }
                }
            }
            catch (Exception e1)
            {
                if (MessageBox.Show("Molim Vas odaberite razred" + "\n" + "Da li bi ste voleli videti detaljnu gresku?", "Neocekivana greska", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    MessageBox.Show("Tacna greska: " + e1.Message);
                }
                else
                {

                }
            }
        }
    }
}
/*
  TODO:Duznici

  */
