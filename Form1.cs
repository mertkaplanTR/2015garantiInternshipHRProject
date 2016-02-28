using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace girisSayfasi
{
    public partial class Form1 : Form
    {
        public string myConnection = "datasource=localhost;port=3306;username=root;password=;database=newdatabase";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            MaximizeBox = false;
            AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand SelectCommand = new MySqlCommand("select * from admin where username='" + this.textBox1.Text + "' and password='" + this.textBox2.Text + "';", myConn);
            MySqlDataReader myReader;
            myConn.Open();
            myReader = SelectCommand.ExecuteReader();
            int count = 0;
            while (myReader.Read())
            {
                count = count + 1;
            }

            if (count==1)
            {
       
                Form1 formkapa = new Form1();
                formkapa.Close();
                Form3 formac = new Form3();
                formac.Show();
                this.Hide();
            }
            else if (count > 1)
            {
                MessageBox.Show("Erişim Engellendi");
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre Girdiniz.");
            }
            myConn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
