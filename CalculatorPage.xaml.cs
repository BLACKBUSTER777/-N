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
    /// Логика взаимодействия для CalculatorPage.xaml
    /// </summary>
    public partial class CalculatorPage : Page
    {
        public CalculatorPage()
        {
            InitializeComponent();
        }

        private void OpenDescartes_Click(object sender, RoutedEventArgs e)
        {
            CalcFrame.Navigate(new CalcalutorDescartes());
        }

        private void OpenPolarDeg_Click(object sender, RoutedEventArgs e)
        {
            CalcFrame.Navigate(new CalculatorPolarDeg());
        }

        private void OpenPolarRad_Click(object sender, RoutedEventArgs e)
        {
            CalcFrame.Navigate(new CalculatorPolarRad());
        }
    }
}
