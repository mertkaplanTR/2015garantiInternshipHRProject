using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace girisSayfasi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 formkapa = new Form3();
            formkapa.Close();
            Form2 formac = new Form2();
            formac.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 formkapa = new Form3();
            formkapa.Close();
            Form5 formac = new Form5();
            formac.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 formkapa = new Form3();
            formkapa.Close();
            Form4 formac = new Form4();
            formac.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 formkapa = new Form3();
            formkapa.Close();
            Form6 formac = new Form6();
            formac.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 formkapa = new Form3();
            formkapa.Close();
            Form7 formac = new Form7();
            formac.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
        }
    }
}
