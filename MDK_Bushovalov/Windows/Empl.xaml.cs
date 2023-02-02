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
    /// Логика взаимодействия для Empl.xaml
    /// </summary>
    public partial class Empl : Window
    {
        public Empl()
        {
            InitializeComponent();
            Classes.AllData.empl = this;
            LoadData();
        }
        public void LoadData()
        {
            Empls.Children.Clear();
            System.Data.DataTable table = new System.Data.DataTable();
            MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT UserID FROM Users", Classes.AllData.con);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Empls.Children.Add(new SystemData.UCEmpl(table.Rows[i][0].ToString()));
            }
        }
    }
}
