using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MDK_Bushovalov.Windows
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
            Classes.AllData.con.Open();
            Classes.AllData.auth = this;
        }

        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT UserID from Users where UserLogin = '{Login.Text}' and UserPassword = '{Password.Text}'", Classes.AllData.con);
            adapter.Fill(table);
            if (Login.Text.Length != 0 && Password.Text.Length != 0)
            {
                if (table.Rows.Count != 0)
                {
                    Classes.AllData.ID = table.Rows[0][0].ToString();
                    Empl menu = new Empl();
                    menu.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Не верны логин или пароль!");
            }
            else
                MessageBox.Show("Заполните все поля!");
        }

        private void Button_Regestrate_Click(object sender, RoutedEventArgs e)
        {
            Windows.Reg registration = new Windows.Reg();
            registration.Show();
            this.Hide();
        }
    }
}
