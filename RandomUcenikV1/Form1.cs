using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RandomUcenikV1
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRect
(
   int leftRect,
   int topRect,
   int rightRect,
   int bottomRect,
   int widthEllipse,
   int heightEllipse
   );
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRect(0, 0, Width, Height, 15, 15));
        }

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        bool provera = true;
        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(1, 1, button1.Width - -25, button1.Height - 2);
            button4.Region = new Region(p);
            button5.Region = new Region(p);
            button6.Region = new Region(p);
            button7.Region = new Region(p); 
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);

            }
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.kontrola11.BringToFront();
            this.kontrola11.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.webSajt1.BringToFront();
            this.webSajt1.Visible = true;
        } 

        private void groupBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            switch (provera)
            {
                case false:
                    for (int i = 0; i < 80; i++)
                    {
                        panel1.Width += 1;
                    }
                    provera = true;
                    break;
                case true:
                    for (int i = 0; i < 80; i++)
                    {
                        panel1.Width -= 1;
                    }
                    provera = false;
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.sistemZaIzbaciUbaci1.BringToFront();
            this.sistemZaIzbaciUbaci1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}