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

namespace Complex_Interface_WPF
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Page
    {
        public Info()
        {
            InitializeComponent();
            InfoImage1.Visibility = Visibility.Visible;
            InfoImage2.Visibility = Visibility.Collapsed;
        }

        private void To1st_Click(object sender, RoutedEventArgs e)
        {
            InfoImage1.Visibility = Visibility.Visible;
            InfoImage2.Visibility = Visibility.Collapsed;
        }
        private void To2nd_Click(object sender, RoutedEventArgs e)
        {
            InfoImage1.Visibility = Visibility.Collapsed;
            InfoImage2.Visibility = Visibility.Visible;
        }
    }
}
