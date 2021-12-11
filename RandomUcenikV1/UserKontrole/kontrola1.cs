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

        private void timer1_Tick(object sender, EventArgs e)
        {

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
        //=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+//
        int abc = 0;

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bool proveraStanja = true;
            PozicijePanela1.x = panel2.Location.X;
            PozicijePanela1.y = panel2.Location.Y;

            switch (proveraStanja)
            {
                case true:
                    panel2.Location = new Point(PozicijePanela1.x, PozicijePanela1.y -= 280);
                    abc = PozicijePanela1.y;
                    proveraStanja = false;
                    break;
                case false:
                    panel2.Location = new Point(PozicijePanela1.x, abc += 280);

                    proveraStanja = true;
                    break;
            }
        }

        string path2;
        int brojUcenika1 = 0;
        string[] izmenaUcenici;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                switch (comboBox2.SelectedIndex)
                {
                    case 0:
                        path2 = Path.GetFullPath("11.txt");
                        break;
                    case 1:
                        path2 = Path.GetFullPath("12.txt");
                        break;
                    case 2:
                        path2 = Path.GetFullPath("13.txt");
                        break;
                    case 3:
                        path2 = Path.GetFullPath("primer1.txt");
                        break;
                }
                StreamReader citacIzmene = new StreamReader(path2);
                string temp2;
                while (!citacIzmene.EndOfStream)
                {
                    temp2 = citacIzmene.ReadLine();
                    brojUcenika1++;
                }
                int temp1 = 0;
                izmenaUcenici = new string[brojUcenika1];

                citacIzmene.BaseStream.Seek(0, SeekOrigin.Begin);
                { }
                while (!citacIzmene.EndOfStream)
                {
                    izmenaUcenici[temp1] = citacIzmene.ReadLine();
                    temp1++;
                }
                for (int i = 0; i < brojUcenika1; i++)
                {
                    listBox2.Items.Add(izmenaUcenici[i]);
                }
                citacIzmene.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Doslo je do greske. Restartujte aplikaciju. Kod greske: X23H1");
            }
        }

        //=+=+=+=+=+=+=+=+=+=+IZBACIVANJE UCENIKA =+=+=+=+=+=+=+=+=+=+
        int prosirenjeRazreda;
        private void button2_Click(object sender, EventArgs e)
        { 
            int izabranIndeksIzbaci = listBox2.SelectedIndex - 1; //targer index
            string[] nizReadyForOverWrite = izmenaUcenici;

            for (int i = izabranIndeksIzbaci; i < brojUcenika1 - 1; i++)
            {
                nizReadyForOverWrite[i] = nizReadyForOverWrite[i + 1];
            }
            string[] nizOverWrite = new string[nizReadyForOverWrite.Length - 1];
            for (int i = 0; i < nizReadyForOverWrite.Length - 1; i++)
            {
                nizOverWrite[i] = nizReadyForOverWrite[i];
            }
            //konacno prepisivanje
            StreamWriter finalOverWrite = new StreamWriter(path2);
            //     finalOverWrite.Flush();
            for (int i = 0; i < nizOverWrite.Length; i++)
            {
                finalOverWrite.WriteLine(nizOverWrite[i]);
            }
            finalOverWrite.Close();
        }
        //_-=SISTEM ZA DODAVANJE=-_
        private void button3_Click(object sender, EventArgs e)
        {
            string[] nizDodavanjaDjaka = new string[brojUcenika1];

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            switch (radioButton3.Checked)
            {
                case true:
                    button3.Enabled = true;
                    button2.Enabled = false;
                    textBox1.Enabled = true;
                    break;
                case false:
                    button3.Enabled = false;
                    button2.Enabled = true;
                    textBox1.Enabled = false; 
                    break;
            }
        }
    }
}
/*
  TODO:Duznici

  */
