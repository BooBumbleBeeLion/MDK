using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
            BirthDate.DisplayDateEnd = DateTime.Now.AddYears(-18);
        }

        private void Button_Registrate_Click(object sender, RoutedEventArgs e)
        {
            if (FIO.Text.Length != 0 && Passport.Text.Length != 0 && Phone.Text.Length != 0 && Login.Text.Length != 0 && Password.Text.Length != 0 && BirthDate.Text.Length != 0)
            {
                MySqlCommand command = new MySqlCommand($"insert into Users(UserFIO, UserBirthDate, UserPhone, UserPassport, UserStatus, UserLogin, UserPassword, UserHireDate) values ('{FIO.Text}', '{BirthDate.DisplayDate.ToString("yyyy-MM-dd")}', '{Phone.Text}', '{Passport.Text}', 'Работает', '{Login.Text}', '{Password.Text}', '{DateTime.Now.ToString("yyyy-MM-dd")}')", Classes.AllData.con);
                command.ExecuteNonQuery();
                Classes.AllData.auth.Show();
                this.Close();
            }
            else
                MessageBox.Show("Заполните все поля!");
        }
    }
}
