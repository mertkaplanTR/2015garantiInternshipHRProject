using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.IO;

namespace girisSayfasi
{

    public partial class Form7 : Form
    {
        MySqlConnection baglanti;
        public Form7()
        {
            InitializeComponent();
        }
        MySqlConnection mcon = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand mcd;
        MySqlDataReader mdr;
        string s;
        private void baglan()
        {
            string bag;
            MySqlConnectionStringBuilder build = new MySqlConnectionStringBuilder();
            build.UserID = "root";
            build.Password = "";
            build.Database = "newdatabase";
            build.Server = "localhost";
            bag = build.ToString();
            baglanti = new MySqlConnection(bag);
            string sql = "select * from kullanici";
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();

            command.CommandText = sql;
            command.Connection = baglanti;
            adapter.SelectCommand = command;
            baglanti.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void sil()
        {
            string bag;
            MySqlConnectionStringBuilder build = new MySqlConnectionStringBuilder();
            build.UserID = "root";
            build.Password = "";
            build.Database = "newdatabase";
            build.Server = "localhost";
            bag = build.ToString();
            baglanti = new MySqlConnection(bag);
            string sql = "DELETE FROM kullanici WHERE idkullanici=" + textBox1.Text +";";
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            command.CommandText = sql;
            command.Connection = baglanti;
            adapter.SelectCommand = command;
         //   baglanti.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan();
        }


        private void button2_Click(object sender, EventArgs e)
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
                    sil();
                    baglan();
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
        }


        
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            baglan();
            this.ControlBox = false;
            this.MaximizeBox = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 formkapa = new Form7();
            formkapa.Close();
            Form3 formac = new Form3();
            formac.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //important
            if (e.RowIndex > 0)
            {
                mcon.Close();
                mcon.Open();
                int i = e.RowIndex;//get the Row Index
                DataGridViewRow row = dataGridView1.Rows[i];
                textBox1.Text = row.Cells[0].Value.ToString();
                mcon.Close();
                mcon.Open();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}