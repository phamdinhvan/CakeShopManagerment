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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBClass.openConnection();

            DBClass.sql = "SELECT P.ProID AS N'Mã loại', P.CategoriesID AS N'Mã Bánh',C.Name AS N'Loại Bánh', P.Name AS N'Tên Bánh', P.Price AS N'Giá(VNĐ)' " +
                "FROM PRODUCTS AS P, CATEGORIES AS C WHERE C.CategoriesID = P.CategoriesID;";
            DBClass.cmd.CommandType = CommandType.Text;
            DBClass.cmd.CommandText = DBClass.sql;

            DBClass.da = new SqlDataAdapter(DBClass.cmd);
            DBClass.dt = new DataTable();
            DBClass.da.Fill(DBClass.dt);

            myDataGrid.ItemsSource = DBClass.dt.DefaultView;
            DBClass.closeConnection();
        }
            
        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            DBClass.openConnection();

            DBClass.sql = "SELECT P.ProID AS N'Mã loại', P.CategoriesID AS N'Mã Bánh',C.Name AS N'Loại Bánh', P.Name AS N'Tên Bánh'," +
                " P.Price AS N'Giá(VNĐ)' FROM PRODUCTS AS P,CATEGORIES AS C WHERE P.Name LIKE '%"+txtBox.Text+ "%' AND P.CategoriesID = C.CategoriesID ;";
            DBClass.cmd.CommandType = CommandType.Text;
            DBClass.cmd.CommandText = DBClass.sql;

            DBClass.da = new SqlDataAdapter(DBClass.cmd);
            DBClass.dt = new DataTable();
            DBClass.da.Fill(DBClass.dt);

            myDataGrid.ItemsSource = DBClass.dt.DefaultView;
            DBClass.closeConnection();
        }
    }
}
