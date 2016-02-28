using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Data.SqlClient;
namespace girisSayfasi
{
    public partial class Form4 : Form
    {
        MySqlConnection mcon = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=newdatabase");
        MySqlCommand mcd;
        MySqlCommand comd2;
        MySqlConnection conn= new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=newdatabase");

        public Form4()
        {
            InitializeComponent();
        }

        public string GetMD5(string Text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(textBox1.Text, out n);

            string q = "insert into newdatabase.kullanici (idKullanici,kullaniciAdi,kullaniciSifre) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Lütfen geçerli bir değer giriniz.");
            }
            else
                if (n == 0)
                {
                    MessageBox.Show("ID kısmını lütfen sayılardan oluşacak şekilde doldurunuz.");
                }
                else
                {
                    textBox3.Text = GetMD5(textBox3.Text);
                    ExecuteQuery(q);
                }

        }
              
        
                
        

                        

                       
                    
                
      
        
  






        
        public void openCon()
        {
            if (mcon.State == ConnectionState.Closed)
            {
                mcon.Open();
            }
        }

        public void closeCon()
        {
            if (mcon.State == ConnectionState.Open)
            {
                mcon.Close();
            }
        }

        public void ExecuteQuery(string q)
        {
            try
            {
                openCon();
                mcd = new MySqlCommand(q, mcon);
                if (mcd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Kullanıcı başarı ile eklendi.");
                }
                else
                {
                    MessageBox.Show("Kullanıcı ekleme başarısız oldu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeCon();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 formkapa = new Form4();
            formkapa.Close();
            Form3 formac = new Form3();
            formac.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

    }
}







