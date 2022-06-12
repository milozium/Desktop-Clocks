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
    public partial class Календарь : Form
    {
        private readonly Color HOLIDAY_COLOR = Color.FromArgb(85, 238, 82, 83);
        private readonly Color DAY_COLOR = Color.FromArgb(255, 24, 242, 242);
        private readonly Color PREVIOUS_MONTH_DAY_COLOR = Color.FromArgb(155, 134, 47, 62);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool ReleaseCapture();

        public Календарь()
        {
            Program.f2 = this;
            InitializeComponent(); 
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("HH:mm");
            this.label2.Text = DateTime.Now.ToString(":ss");

            int r = 255;
            int g = 0;
            int b = 75;


            Color color = Color.FromArgb(r, g, b);   // Про цвет


            this.label1.ForeColor = color;
            this.label2.ForeColor = color;


            this.button1.Text = DateTime.Now.ToString("dd:MM:yyyy");
        }

        private void Календарь_MouseDown(object sender, MouseEventArgs e)
        {
            const uint WM_SYSCOMMAND = 0x0112;
            const uint DOMOVE = 0xF012;

            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form Form1 = Application.OpenForms[0];
            Form1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            const uint WM_SYSCOMMAND = 0x0112;
            const uint DOMOVE = 0xF012;

            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void daysofWeek4_Load(object sender, EventArgs e)
        {



        }

        private void daysofWeek3_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Календарь_Load(object sender, EventArgs e)
        {
            Program.f2 = this;
            DisplayDays(DateTime.Now);
        }
        private void DisplayDays(DateTime date)
        {
            var now = date;
            var previousMonth = date.AddMonths(-1);

            var startOfTheMonth = new DateTime(now.Year, now.Month, 1);

            int days = DateTime.DaysInMonth(now.Year, now.Month);
            int previousMonthDays = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);

            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d")) == 0
                ? 7
                : Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d"));

            dayOfTheWeek = dayOfTheWeek == 1 ? 8 : dayOfTheWeek;
            //Заполняем дни предыдущего месяца
            for (int i = 1; i < dayOfTheWeek; i++)
            {
                (tableLayoutPanel1.Controls[42 - i] as DayBlank).Refresh(PREVIOUS_MONTH_DAY_COLOR,
                    (previousMonthDays - dayOfTheWeek + i + 1),
                    new DateTime(previousMonth.Year, previousMonth.Month, (previousMonthDays - dayOfTheWeek + i + 1)),
                    Color.LightGray);
            }
            // Заполняем дни текущего месяца
            for (int i = 0; i < days; i++)
            {
                if ((42 - i - dayOfTheWeek) % 7 == 0 || (42 - i - dayOfTheWeek - 1) % 7 == 0)
                {
                    (tableLayoutPanel1.Controls[42 - i - dayOfTheWeek] as DayBlank).Refresh(HOLIDAY_COLOR,
                        i + 1,
                        new DateTime(now.Year, now.Month, i + 1),
                        Color.Azure);
                }
                else
                {
                    (tableLayoutPanel1.Controls[42 - i - dayOfTheWeek] as DayBlank).Refresh(DAY_COLOR,
                        i + 1,
                        new DateTime(now.Year, now.Month, i + 1),
                        Color.Azure);
                }
            }

            // Заполняем дни след. месяца
            int otherDays = 42 - days - dayOfTheWeek;
            for (int i = otherDays; i >= 0; i--)
            {
                (tableLayoutPanel1.Controls[i] as DayBlank).Refresh(PREVIOUS_MONTH_DAY_COLOR,
                    otherDays - i + 1,
                    new DateTime(now.AddMonths(1).Year, now.AddMonths(1).Month, otherDays - i + 1),
                    Color.LightGray);
            }
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            const uint WM_SYSCOMMAND = 0x0112;
            const uint DOMOVE = 0xF012;

            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }
    }
}
