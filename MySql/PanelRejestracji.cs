using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace MySql
{
    public partial class PanelRejestracji : Form1
    {
        public PanelRejestracji()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Logowanie = new Form1();
            Logowanie.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;
            string email = textBox2.Text;
            string narodowosci = textBox3.Text;
            string haslo = textBox4.Text;
            string powtorzhaslo = textBox5.Text;
            string karnet = comboBox1.Text;
            if (Register(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, comboBox1.Text)) ;
            {
                MessageBox.Show($"Użytkownik {Login} został zarejestrowany!");
            }
            
            else{
                MessageBox.Show($"Użytkownik{Login} nie został zarejestrowany!");
            }
        }

        public bool Register(string Login, string email, string haslo, string powtorzhaslo, string narodowosci, string karnecik)
        {
            string query = $"INSERT INTO rejestracja (Login, email, narodowosc, haslo, powtorzhaslo, karnecik) VALUES ('{Login}','{email}','{narodowosci},'{haslo}','{powtorzhaslo}','{karnecik}');";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }

            }


            }
    }
}



            
            
 
         



        
                 
           
      
        
    
