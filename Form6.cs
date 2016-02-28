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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        MySqlConnection mcon = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand mcd;
        MySqlDataReader mdr;
        string s;

        private void Form6_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.MaximizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text== "")
            {
                MessageBox.Show("Lütfen ID yazarak tekrar deneyin.");
            }
            else
            { 
            try
            {
                mcon.Open();
                if (textBox1.Text != "" || textBox1.Text != null)
                    s = "select * from newdatabase.kullanici where idkullanici =" + int.Parse(textBox1.Text);
                mcd = new MySqlCommand(s, mcon);
                mdr = mcd.ExecuteReader();

                if (mdr.Read())
                {
                    textBox1.Text = mdr.GetString("idkullanici");
                    textBox2.Text = mdr.GetString("kullaniciAdi");
                    textBox3.Text = mdr.GetString("kullaniciSifre");
                }
                else
                {
                    MessageBox.Show("Böyle bir ID değerli kullanıcı bulunamadı.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mdr.Close();
                mcon.Close();
            }
        }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form6 formkapa = new Form6();
            formkapa.Close();
            Form3 formac = new Form3();
            formac.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }
      
        }
    }

