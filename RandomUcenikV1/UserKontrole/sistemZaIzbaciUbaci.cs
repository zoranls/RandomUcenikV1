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
    public partial class sistemZaIzbaciUbaci : UserControl
    {
        public sistemZaIzbaciUbaci()
        {
            InitializeComponent();
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
            catch (Exception e1)
            {
                if (MessageBox.Show("Doslo je do neocekivane greske. Molim vas pokrenite ponovo aplikaciju." + "\n" + "Da li bi ste voleli videti detaljnu gresku?", "Neocekivana greska", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    MessageBox.Show("Tacna greska: " + e1.Message);
                }
                else
                {

                }
            }
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

        //=+=+=+=+=+=+=+=+=+=+IZBACIVANJE UCENIKA =+=+=+=+=+=+=+=+=+=+

        int prosirenjeRazreda;
        private void button2_Click(object sender, EventArgs e)
        {
            try
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
                MessageBox.Show("Uspesno uklonjen odabir. \n Molim Vas pokrenite ponovo aplikaciju kako bi videli izmene.");
            }
            catch (Exception e1)
            {
                if (MessageBox.Show("Molim Vas odaberite razred ili ucenika za izbacivanje." + "\n" + "Da li bi ste voleli videti detaljnu gresku?", "Neocekivana greska", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    MessageBox.Show("Tacna greska: " + e1.Message);
                }
                else
                {

                }
            }
        }

        //_-=SISTEM ZA DODAVANJE=-_
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Unesi vrednost.");
            }
            else
            {
                string[] nizDodavanjaDjaka = new string[brojUcenika1 + 1];
                int brojIndeksiranja = 0;
                while (nizDodavanjaDjaka[brojIndeksiranja] == null)
                {
                    brojIndeksiranja++;
                } 
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex<0)
            {
                textBox1.Text = "";
                MessageBox.Show("Izaberite zazred.");
            }

        }
    }
}
