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
    /// Interaction logic for ListCake.xaml
    /// </summary>
    public partial class ListCake : Window
    {
        public ListCake()
        {
            InitializeComponent();
        }

        private void BanhMi_Click(object sender, RoutedEventArgs e)
        {
            var scr = new BanhMi();
            scr.ShowDialog();
        }

        private void Banhngot_Click(object sender, RoutedEventArgs e)
        {
            var scr = new BanhNgot();
            scr.ShowDialog();
        }

        private void Banhkem_Click(object sender, RoutedEventArgs e)
        {
            var scr = new BanhKemNho();
            scr.ShowDialog();
        }

        private void Banhkemnho_Click(object sender, RoutedEventArgs e)
        {
            var scr = new BanhKem();
            scr.ShowDialog();
                
        }
    }
}
