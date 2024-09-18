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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            InitialText.Visibility = Visibility.Collapsed;
            SFrame.Navigate(new CalculatorPage());
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            InitialText.Visibility = Visibility.Collapsed;
            SFrame.Navigate(new Page3());
        }

        private void SFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            InitialText.Visibility = Visibility.Collapsed;
            SFrame.Navigate(new Info());
        }

        private void Exponentiation_Click(object sender, RoutedEventArgs e)
        {
            InitialText.Visibility = Visibility.Collapsed;
            SFrame.Navigate(new ExponentiationPage());
        }
    }
}
