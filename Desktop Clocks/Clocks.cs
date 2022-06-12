using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Курсовая
{
    public partial class Часы : Form
    {

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool ReleaseCapture();



        int cx=445, cy=344;
        int secLine = 200, minLine = 190, hrLine = 175;
        Timer t = new Timer();

        private Random rnd = new Random(); // Настоящий цвет
        public Часы()
        {

            Program.f1 = this;



            InitializeComponent();
            //this.BackColor = Color.AliceBlue;       // Важная строка.....фаифьомрифгаицлормифолвгчнмпрриацьривмоР
            //this.TransparencyKey = this.BackColor;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g;
            g = pictureBox1.CreateGraphics();
            g.DrawEllipse(Pens.Black,175, 70, 550, 550); //первая и вторая (x,y) координаты отвечают за центр часов...

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;  //В миллисекундах
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void Часы_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            

            //// RGB ///TIME

            this.label1.Text = DateTime.Now.ToString("HH:mm");
            this.label2.Text = DateTime.Now.ToString(":ss");

            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);


            Color color = Color.FromArgb(r, g, b);   // Про цвет


            this.label1.ForeColor = color;
            this.label2.ForeColor = color;
            this.label3.ForeColor = color;
            this.label6.ForeColor = color;
            this.label9.ForeColor = color;
            this.label12.ForeColor = color;

            ////Greetings
            ///



            dynamic ptr;
            ptr = DateTime.Now;
            DateTime dt = new DateTime(2022, 5, 6, 12, 0, 0);



            if (ptr.Hour <= dt.Hour && ptr.Hour >= 5)   //5<time<12
                this.label15.Text = "Morning to you!";
            if (ptr.Hour >= 12 && ptr.Hour <= 18)       //12<time<18
                this.label15.Text = "Welcome here!"; 
            if (ptr.Hour >= 18 && ptr.Hour <= 23)    //18<time<23
                this.label15.Text = " ";
            if (ptr.Hour < 5)                          // 0<time<5
                this.label15.Text = " ";


            if (ptr.Hour <= dt.Hour && ptr.Hour >= 5)   //5<time<12
                this.label16.Text = " ";
            if (ptr.Hour >= 12 && ptr.Hour <= 18)       //12<time<18
                this.label16.Text = " ";
            if (ptr.Hour >= 18 && ptr.Hour <= 23)    //18<time<23
                this.label16.Text = "Good evening!";
            if (ptr.Hour < 5)                          // 0<time<5
                this.label16.Text = "Bedtime";



            ///////DATA KALENDAR

            this.button1.Text = DateTime.Now.ToString("dd:MM:yyyy");





            /////// Timer
            







        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Часы_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            const uint WM_SYSCOMMAND = 0x0112;
            const uint DOMOVE = 0xF012;

            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            const uint WM_SYSCOMMAND = 0x0112;
            const uint DOMOVE = 0xF012;

            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        { 

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (my.календарь == null)
                my.календарь = new Календарь();
            my.календарь.Show();

            this.Hide();
        }

        private void Settings_Click(object sender, EventArgs e)
        {

            if (my.settings == null)
                my.settings = new Settings();
            my.settings.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
      
        }

        private int[] msCoord(int val, int hlen) // Секунды и минуты                    //////////ЦИФЕРБЛАТ BACKEND 
        {
            int[] coord = new int[2];
            val *= 6;

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180)); //В радианах...
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180)); 
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180)); // В другую сторону..
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }
        private int[] hrCoord(int hval, int mval, int hlen)  // Для часов          д
        {
            int[] coord = new int[2];
            int val = (int)((hval * 30) + (mval * 0.5));

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }
        private void t_Tick(object sender, EventArgs e)
        {

            //Берём время.                                                                          //////////ЧАСЫ FRONTEND
            int s = DateTime.Now.Second;
            int m = DateTime.Now.Minute;
            int h = DateTime.Now.Hour;

            int[] handCoord = new int[2];

            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Control.DefaultBackColor, 3);
            // Стираем предыдущее положения секундной стрелки
            if (my.radiobutton_checked)
            {
                Console.WriteLine("1");
                handCoord = msCoord(s, secLine + 4);
                g.DrawLine(new Pen(Color.Black, 45f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
            else if (my.radiobutton1_checked)
            {
                Console.WriteLine("2");
                handCoord = msCoord(s, secLine + 4);
                g.DrawLine(new Pen(Color.LightSeaGreen, 45f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
            else if (my.radiobutton2_checked)
            {
                Console.WriteLine("3");
                handCoord = msCoord(s, secLine + 4);
                g.DrawLine(new Pen(Control.DefaultBackColor, 45f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
            else
            {
                Console.WriteLine("4");
                handCoord = msCoord(s, secLine + 4);
                g.DrawLine(new Pen(Control.DefaultBackColor, 45f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
            // Стираем предыдущее положение минутной стрелки
            if (my.radiobutton_checked)
            {
                handCoord = msCoord(m, minLine + 4);
                g.DrawLine(new Pen(Color.Black, 40f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
            else if (my.radiobutton1_checked)
            {
                handCoord = msCoord(m, minLine + 4);
                g.DrawLine(new Pen(Color.LightSeaGreen, 40f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
            else if (my.radiobutton2_checked)
            {
                handCoord = msCoord(m, minLine + 4);
                g.DrawLine(new Pen(Control.DefaultBackColor, 40f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
            else
            {
                handCoord = msCoord(m, minLine + 4);
                g.DrawLine(new Pen(Control.DefaultBackColor, 40f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
            // Стираем предыдущее положение часовой стрелки
            if (my.radiobutton_checked)
            {
                handCoord = hrCoord(h % 12, m, hrLine + 4);
                g.DrawLine(new Pen(Color.Black, 20f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
            else if (my.radiobutton1_checked)
            {
                handCoord = hrCoord(h % 12, m, hrLine + 4);
                g.DrawLine(new Pen(Color.LightSeaGreen, 20f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
            else if (my.radiobutton2_checked)
            {
                handCoord = hrCoord(h % 12, m, hrLine + 4);
                g.DrawLine(new Pen(Control.DefaultBackColor, 20f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
            else
            {
                handCoord = hrCoord(h % 12, m, hrLine + 4);
                g.DrawLine(new Pen(Control.DefaultBackColor, 20f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            }
                //Отрисовка стрелки часов.
                handCoord = hrCoord(h % 12, m, hrLine);
            g.DrawLine(new Pen(Color.Gray, 4f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));


            //Отрисовка минутной стрелки
            handCoord = msCoord(m, minLine);
            g.DrawLine(new Pen(Color.Brown, 2f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            // Отрисовка секундной стрелки.
            handCoord = msCoord(s, secLine);
            g.DrawLine(new Pen(Color.DarkOrange, 2f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            //g.Clear(Color.MistyRose);
        }
    }
}
