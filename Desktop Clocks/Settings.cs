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
    
   
    public partial class Settings : Form
    {
        
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool ReleaseCapture();

        
        public Settings()
        {
            Program.f3 = this;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Form1 = Application.OpenForms[0];
            Form1.Show();
            this.Hide();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void Settings_Load(object sender, EventArgs e)
        {
                radioButton1.Checked = my.radiobutton_checked;
                radioButton2.Checked = my.radiobutton1_checked;
                radioButton3.Checked = my.radiobutton2_checked;
        }

        private void Settings_MouseDown(object sender, MouseEventArgs e)
        {
            const uint WM_SYSCOMMAND = 0x0112;
            const uint DOMOVE = 0xF012;

            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }

        private void button2_Click(object sender, EventArgs e)      //f1 means Form1 that is Clocks; f2 means Data
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            my.radiobutton_checked = radioButton1.Checked;
            if (my.radiobutton_checked)
            {
                
                //Clocks
                Program.f1.pictureBox1.BackColor = System.Drawing.Color.FromArgb(41,41,41);
                Program.f1.label1.BackColor = System.Drawing.Color.Black;
                Program.f1.label2.BackColor = System.Drawing.Color.Black;
                Program.f1.label3.BackColor = System.Drawing.Color.Black;
                Program.f1.label4.BackColor = System.Drawing.Color.Black;
                Program.f1.label5.BackColor = System.Drawing.Color.Black;
                Program.f1.label6.BackColor = System.Drawing.Color.Black;
                Program.f1.label7.BackColor = System.Drawing.Color.Black;
                Program.f1.label8.BackColor = System.Drawing.Color.Black;
                Program.f1.label9.BackColor = System.Drawing.Color.Black;
                Program.f1.label10.BackColor = System.Drawing.Color.Black;
                Program.f1.label11.BackColor = System.Drawing.Color.Black;
                Program.f1.label12.BackColor = System.Drawing.Color.Black;
                Program.f1.label13.BackColor = System.Drawing.Color.Black;
                Program.f1.label14.BackColor = System.Drawing.Color.Black;
                Program.f1.label15.BackColor = System.Drawing.Color.Black;
                Program.f1.label16.BackColor = System.Drawing.Color.Black;
                Program.f1.button1.BackColor = System.Drawing.Color.Black;
                Program.f1.Settings.BackColor = System.Drawing.Color.Black;
                Program.f1.pictureBox1.BackColor = System.Drawing.Color.Black;
                // Календарь
                Program.f2.pictureBox1.BackColor = System.Drawing.Color.Black;
                Program.f2.label1.BackColor = System.Drawing.Color.Black;
                Program.f2.label2.BackColor = System.Drawing.Color.Black;
                Program.f2.label3.BackColor = System.Drawing.Color.Black;
                Program.f2.label4.BackColor = System.Drawing.Color.Black;
                Program.f2.label5.BackColor = System.Drawing.Color.Black;
                Program.f2.label6.BackColor = System.Drawing.Color.Black;
                Program.f2.label7.BackColor = System.Drawing.Color.Black;
                Program.f2.label8.BackColor = System.Drawing.Color.Black;
                Program.f2.label9.BackColor = System.Drawing.Color.Black;
                Program.f2.button1.BackColor = System.Drawing.Color.Black;
                Program.f2.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            my.radiobutton1_checked = radioButton2.Checked;
            if (my.radiobutton1_checked)
            {
                Program.f1.pictureBox1.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.pictureBox1.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label1.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label2.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label3.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label4.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label5.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label6.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label7.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label8.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label9.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label10.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label11.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label12.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label13.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label14.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label15.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.label16.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.button1.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.Settings.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f1.pictureBox1.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.pictureBox1.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.label1.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.label2.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.label3.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.label4.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.label5.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.label6.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.label7.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.label8.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.label9.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.button1.BackColor = System.Drawing.Color.LightSeaGreen;
                Program.f2.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSeaGreen;
            }
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            my.radiobutton2_checked = radioButton3.Checked;
            if (my.radiobutton2_checked)
            {
                Program.f1.pictureBox1.BackColor = Control.DefaultBackColor;
                Program.f1.pictureBox1.BackColor = Control.DefaultBackColor;
                Program.f1.label1.BackColor = Control.DefaultBackColor;
                Program.f1.label2.BackColor = Control.DefaultBackColor;
                Program.f1.label3.BackColor = Control.DefaultBackColor;
                Program.f1.label4.BackColor = Control.DefaultBackColor;
                Program.f1.label5.BackColor = Control.DefaultBackColor;
                Program.f1.label6.BackColor = Control.DefaultBackColor;
                Program.f1.label7.BackColor = Control.DefaultBackColor;
                Program.f1.label8.BackColor = Control.DefaultBackColor;
                Program.f1.label9.BackColor = Control.DefaultBackColor;
                Program.f1.label10.BackColor = Control.DefaultBackColor;
                Program.f1.label11.BackColor = Control.DefaultBackColor;
                Program.f1.label12.BackColor = Control.DefaultBackColor;
                Program.f1.label13.BackColor = Control.DefaultBackColor;
                Program.f1.label14.BackColor = Control.DefaultBackColor;
                Program.f1.label15.BackColor = Control.DefaultBackColor;
                Program.f1.label16.BackColor = Control.DefaultBackColor;
                Program.f1.button1.BackColor = Control.DefaultBackColor;
                Program.f1.Settings.BackColor = Control.DefaultBackColor;
                Program.f1.pictureBox1.BackColor = Control.DefaultBackColor;
                Program.f2.pictureBox1.BackColor = Control.DefaultBackColor;
                Program.f2.label1.BackColor = Control.DefaultBackColor;
                Program.f2.label2.BackColor = Control.DefaultBackColor;
                Program.f2.label3.BackColor = Control.DefaultBackColor;
                Program.f2.label4.BackColor = Control.DefaultBackColor;
                Program.f2.label5.BackColor = Control.DefaultBackColor;
                Program.f2.label6.BackColor = Control.DefaultBackColor;
                Program.f2.label7.BackColor = Control.DefaultBackColor;
                Program.f2.label8.BackColor = Control.DefaultBackColor;
                Program.f2.label9.BackColor = Control.DefaultBackColor;
                Program.f2.button1.BackColor = Control.DefaultBackColor;
                Program.f2.tableLayoutPanel1.BackColor = Control.DefaultBackColor;
            }
           
        }
    }
}
