using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecodation_Formula1_Oyunu
{
    public partial class Form1 : Form
    {
        int zorluk=0;


        int y1=20, y2=220, y3=420;
        int carx, cary;
        int sollanan_arac_sayisi=0;
        double vertical_abs, horizontal_abs;
        double vertical_fark, horizontal_fark;

        Random r = new Random();

        

        Image[] cars =
        {
            Properties.Resources.blue,
            Properties.Resources.yellow,
            Properties.Resources.green

        };

        

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Dock = DockStyle.Fill;
            panel1.Show();
            button1.Enabled = false;



        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Right)
            {
                pictureBox1.Left += 40;
            }
            if (e.KeyCode==Keys.Left)
            {
                pictureBox1.Left -= 40;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (zorluk==1)
            {
                cary += 10;
            }
            else if (zorluk==2)
            {
                cary += 15;
            }
            else if (zorluk==3)
            {
                cary += 20;
            }

            
            pictureBox2.Location = new Point(carx, cary);
            y1 += 20;
            y2 += 20;
            y3 += 20;
            label1.Location = new Point(270, y1);
            label2.Location = new Point(270, y2);
            label3.Location = new Point(270, y3);
            if (y1==600)
            {
                y1 = -40;
            }
            if (y2==600)
            {
                y2 = -40;
            }
            if (y3==600)
            {
                y3 = -40;
            }

            if (cary==600)
            {
                cary = -300;
                carx = r.Next(35, 400);
                pictureBox2.Image = cars[r.Next(0, 3)];
                sollanan_arac_sayisi++;
                if (sollanan_arac_sayisi==20)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Tebrikler Oyunu Kazandınız!","FORMULA 1",MessageBoxButtons.OK);
                    
                }
            }

            //KAZA OLAYI
            vertical_abs = Math.Abs((pictureBox1.Top + pictureBox1.Height / 2) - (pictureBox2.Top - pictureBox2.Height / 2));
            horizontal_abs = Math.Abs((pictureBox1.Left + pictureBox1.Width / 2) - (pictureBox2.Left + pictureBox2.Width / 2));
            vertical_fark = (pictureBox1.Height / 2) - (pictureBox2.Height / 2);
            horizontal_fark = (pictureBox1.Width / 2) - (pictureBox2.Width / 2);

            if (horizontal_abs<75 && vertical_abs<180)
            {
                timer1.Enabled = false;
                pictureBox1.Image = Properties.Resources.boom;
                pictureBox2.Image = Properties.Resources.boom;
                MessageBox.Show("GAME OVER", "FORMULA-1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //ARABA YOLDAN ÇIKMA DURUMU
            if (pictureBox1.Left<-30||pictureBox1.Left>450)
            {
                timer1.Enabled = false;
                MessageBox.Show("YOLDAN ÇIKTIN", "FORMULA-1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel1.Visible = false;

            timer1.Interval = 1;
            timer1.Enabled = true;
            label1.Location = new Point(270, y1);
            label2.Location = new Point(270, y2);
            label3.Location = new Point(270, y3);
            carx = r.Next(35, 400);
            cary = -240;
            pictureBox2.Location = new Point(carx, cary);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            zorluk = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            zorluk = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            zorluk = 3;
        }
    }
}
