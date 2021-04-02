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
    /// Interaction logic for SplashScr.xaml
    /// </summary>
    public partial class SplashScr : Window
    {
        public SplashScr()
        {
            InitializeComponent();
        }

        private void checkBox(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Do not show this dialog when start ", " ", MessageBoxButton.YesNo, MessageBoxImage.Information);
            var scr = new HomeScr();
            this.Hide();
            scr.ShowDialog();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
