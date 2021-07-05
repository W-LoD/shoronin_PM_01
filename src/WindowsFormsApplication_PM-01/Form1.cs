using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication_PM_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool file = false;
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            webBrowser1.Navigate(openFileDialog1.FileName);
                            this.WindowState = FormWindowState.Maximized;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int X = Convert.ToInt32(textBox1.Text);
            int Y = Convert.ToInt32(textBox2.Text);
            int XY = X + Y;
            int X_Y = X - Y;
            if (XY > 5 && XY < 11 && X_Y > -3 && X_Y < 3)
            {
                toolStripStatusLabel1.Text = "Точка попадает в заштрихованную область";
                MessageBox.Show("Точка попадает в заштрихованную область");
            }
            else if(XY == 5 || XY == 11 || X_Y == -3 || X_Y == 3)
            {
                toolStripStatusLabel1.Text = "Точка попадает на границу";
                MessageBox.Show("Точка попадает на границу");
            }
            else
            {
                toolStripStatusLabel1.Text = "Точка не попадает в заштрихованную область или на границу";
                MessageBox.Show("Точка не попадает в заштрихованную область или на границу");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string caption = "О программе";
            MessageBox.Show(@"Автор работы: ст. гр. ПКсп-118 Шоронин Дмитрий Игоревич
Вариант: 14", caption);
        }
    }
}
