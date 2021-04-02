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
    /// Interaction logic for HoaDon.xaml
    /// </summary>
    public partial class HoaDon : Window
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBClass.openConnection();

            DBClass.sql = "SELECT ID AS N'Mã Đơn',ProductID AS N'Mã loại bánh', Name AS N'Tên Bánh',Amount AS N'Số lượng mua'," +
                " Price AS N'Giá(VNĐ)',Total_Amount AS N'Tổng tiền(VNĐ)' FROM ORDER_DETAIL,ORDER_ WHERE ORDER_.OrderID = ORDER_DETAIL.ID;";
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
