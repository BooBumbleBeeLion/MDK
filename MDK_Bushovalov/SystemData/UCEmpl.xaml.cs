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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MDK_Bushovalov.SystemData
{
    /// <summary>
    /// Логика взаимодействия для UCEmpl.xaml
    /// </summary>
    public partial class UCEmpl : UserControl
    {
        string ID;
        public UCEmpl(string ID)
        {
            InitializeComponent();
            this.ID = ID;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT UserFIO, UserPhone, UserPassport, UserHireDate, UserStatus FROM users WHERE UserID = " + ID, Classes.AllData.con);
            adapter.Fill(table);
            Info.Text = table.Rows.Count != 0 ? table.Rows[0][0].ToString() + " | " + table.Rows[0][1].ToString() + " | " + table.Rows[0][2].ToString() + " | " + table.Rows[0][3].ToString() + " | " : "Ошибка!";
            FH.Content = table.Rows[0][4].ToString() == "Работает" ? "Уволить" : "Нанять";
        }

        private void FH_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand com = new MySqlCommand(FH.Content.ToString() == "Уволить" ? "UPDATE Users SET UserStatus = 'Уволен' WHERE UserID = " + ID : "UPDATE Users SET UserStatus = 'Работает' WHERE UserID = " + ID, Classes.AllData.con);
            com.ExecuteNonQuery();
            Classes.AllData.empl.LoadData();
        }
    }
}
