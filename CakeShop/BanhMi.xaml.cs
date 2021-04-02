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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CakeShop.Classes;


namespace CakeShop
{
    /// <summary>
    /// Interaction logic for BanhMi.xaml
    /// </summary>
    public partial class BanhMi : Window
    {

        public BanhMi()
        {
            InitializeComponent();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DBClass.openConnection();

            DBClass.sql = "SELECT CategoriesID AS N'Mã Bánh', Name AS N'Tên Bánh', Price AS N'Giá(VNĐ)' FROM PRODUCTS WHERE CategoriesID = N'BM';";
            DBClass.cmd.CommandType = CommandType.Text;
            DBClass.cmd.CommandText = DBClass.sql;

            DBClass.da = new SqlDataAdapter(DBClass.cmd);
            DBClass.dt = new DataTable();
            DBClass.da.Fill(DBClass.dt);

            myDataGrid.ItemsSource = DBClass.dt.DefaultView;
            DBClass.closeConnection();
        }

        private void myDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void xem_btn_Click(object sender, RoutedEventArgs e)
        {
            var scr = new Bmi_detail();
            scr.ShowDialog();
        }


        private void btAll_Click(object sender, RoutedEventArgs e)
        {
            var scr = new AllCake();
            scr.ShowDialog();
        }
    }

   
}
        

   
