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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CakeShop.Classes;

namespace CakeShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btSubmit_Click(object sender, RoutedEventArgs e)
        {
            

            DBClass.openConnection();

            DBClass.sql = "SELECT * FROM USER_ WHERE Username='" + this.txtUsername.Text.ToString().Trim() + "'";
            DBClass.cmd.CommandType = CommandType.Text;
            DBClass.cmd.CommandText = DBClass.sql;

            DBClass.da = new SqlDataAdapter(DBClass.cmd);
            DBClass.dt = new DataTable();
            DBClass.da.Fill(DBClass.dt);

            
            DBClass.closeConnection();

            if (DBClass.dt.Rows.Count >0)
            {
                var scr = new SplashScr();
                scr.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Username or Password is incorrect");
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
