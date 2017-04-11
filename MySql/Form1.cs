using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MySql
{
    public partial class Form1 : Form
    {
        public MySqlConnection conn;
        private string server;
        private string database;
        private string Login;
        private string Email;
        private string password;
        private string passwordAgain;
        private string Miejscowosc;
        private string Karnet;


        public Form1()
        {
            server = "localhost";
            database = "rejestracja";
            Login = "root";
            password = "";

            string connString;
            connString = $"SERVER={server};DATABASE={database};Login={Login};Email={Email};Narodowosc={Miejscowosc};Haslo={password};Powtorz={passwordAgain};Karnet={Karnet};";

            conn = new MySqlConnection(connString);
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            PanelRejestracji PanelRejestracji = new PanelRejestracji();
            PanelRejestracji.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;


            string haslo = textBox2.Text;


            if (IsLogin(textBox1.Text, textBox2.Text));
            {
                MessageBox.Show($"Witam {Login} !");
               
            
            { 
            else
            {
                MessageBox.Show($"{Login} nie istnieje lub hasło jest nieprawidłowe !");
            }
        }
        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            }
            {


                switch (ex.Number)




                    case 0:
                    MessageBox.Show("Połączenie z serwerem nie udane");
                    break;
                case 1045:
                    MessageBox.Show("Nazwa użytkownika bądź hasło jest niepoprawne");
                    break;
                }
                return false;
            }
        }

        public bool IsLogin(string login, string haslo)
        {
            string query = $"SELECT * FROM rejestracja WHERE Login='{login}' AND password='{haslo}';";

            try

            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        conn.Close();
                        return false;

                    }
                    else
                    {
                        conn.Close();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }

        }


    }
}
