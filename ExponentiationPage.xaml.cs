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
    /// Логика взаимодействия для ExponentiationPage.xaml
    /// </summary>
    public partial class ExponentiationPage : Page
    {
        public ExponentiationPage()
        {
            InitializeComponent();
        }

        private void OpenDescartesExp_Click(object sender, RoutedEventArgs e)
        {
            ExpFrame.Navigate(new ExpDescartes());
        }

        private void OpenPolarDegExp_Click(object sender, RoutedEventArgs e)
        {
            ExpFrame.Navigate(new ExpPolarDeg());
        }

        private void OpenPolarRadExp_Click(object sender, RoutedEventArgs e)
        {
            ExpFrame.Navigate(new ExpPolarRad());
        }
    }
}
