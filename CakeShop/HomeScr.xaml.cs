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

namespace CakeShop
{
    /// <summary>
    /// Interaction logic for HomeScr.xaml
    /// </summary>
    public partial class HomeScr : Window
    {
        public HomeScr()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            var scr = new Search();
            scr.ShowDialog();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            var scr = new ListCake();
            scr.ShowDialog();
        }

        private void stactics_Click(object sender, RoutedEventArgs e)
        {
            var scr = new Statics();
            scr.ShowDialog();
        }

        private void Hoadon_Click(object sender, RoutedEventArgs e)
        {
            var scr = new HoaDon();
            scr.ShowDialog();
        }
    }
}
