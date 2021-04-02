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
    /// Interaction logic for AllCake.xaml
    /// </summary>
    public partial class AllCake : Window
    {

        public AllCake()
        {
            InitializeComponent();
        }
    
        private void dt_loaded()
        {
            DBClass.openConnection();

            DBClass.sql = "SELECT P.ProID AS N'Mã loại', P.CategoriesID AS N'Mã Bánh', P.Name AS N'Tên Bánh', P.Price AS N'Giá(VNĐ)' " +
                "FROM PRODUCTS AS P; ";
            DBClass.cmd.CommandType = CommandType.Text;
            DBClass.cmd.CommandText = DBClass.sql;

            DBClass.da = new SqlDataAdapter(DBClass.cmd);
            DBClass.dt = new DataTable();
            DBClass.da.Fill(DBClass.dt);

            myDataGrid.ItemsSource = DBClass.dt.DefaultView;
            DBClass.closeConnection();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.dt_loaded();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        { 

            DBClass.openConnection();
            DBClass.sql = "INSERT INTO PRODUCTS(ProID, CategoriesID, Name, Price) VALUES (@ProID, @CategoriesID, @Name, @Price)";
            DBClass.cmd.CommandType = CommandType.Text;
            DBClass.cmd.CommandText = DBClass.sql;

            DBClass.cmd.Parameters.AddWithValue("ProID", ProID.Text);
            DBClass.cmd.Parameters.AddWithValue("CategoriesID", CateID.Text);
            DBClass.cmd.Parameters.AddWithValue("Name", Name.Text);
            DBClass.cmd.Parameters.AddWithValue("Price", Price.Text);
            DBClass.cmd.ExecuteNonQuery();
            dt_loaded();
            MessageBox.Show("Bạn đã thêm 1 sản phẩm!");

            DBClass.closeConnection();
        }

        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            DBClass.openConnection();

            DBClass.sql = "DELETE FROM PRODUCTS WHERE ProID= @ProID";
            DBClass.cmd.CommandType = CommandType.Text;
            DBClass.cmd.CommandText = DBClass.sql;

            DBClass.cmd.Parameters.AddWithValue("ProID", ProID.Text);
            DBClass.cmd.Parameters.AddWithValue("CategoriesID", CateID.Text);
            DBClass.cmd.Parameters.AddWithValue("Name", Name.Text);
            DBClass.cmd.Parameters.AddWithValue("Price", Price.Text);
            DBClass.cmd.ExecuteNonQuery();
            dt_loaded();
            MessageBox.Show("Bạn đã xoá 1 sản phẩm!");

            DBClass.closeConnection();
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            DBClass.openConnection();

            DBClass.sql = "UPDATE PRODUCTS SET Name = @Name, Price = @Price WHERE ProID= @ProID AND CategoriesID = @CategoriesID";
            DBClass.cmd.CommandType = CommandType.Text;
            DBClass.cmd.CommandText = DBClass.sql;

            DBClass.cmd.Parameters.AddWithValue("ProID", ProID.Text);
            DBClass.cmd.Parameters.AddWithValue("CategoriesID", CateID.Text);
            DBClass.cmd.Parameters.AddWithValue("Name", Name.Text);
            DBClass.cmd.Parameters.AddWithValue("Price", Price.Text);
            DBClass.cmd.ExecuteNonQuery();
            dt_loaded();
            MessageBox.Show("Cập nhật thành công!");

            DBClass.closeConnection();
        }

        private void resetAll()
        {
            ProID.Text = "";
            CateID.Text = "";
            Name.Text = "";
            Price.Text = "";

            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            del_btn.IsEnabled = false;
        }
        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            this.resetAll();
        }
        
    }
}








