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

namespace SCS_Calc_2._0
{
    /// <summary>
    /// Логика взаимодействия для CalculatePage.xaml
    /// </summary>
    public partial class CalculatePage : Page
    {
        public CalculatePage()
        {
            InitializeComponent();
        }

        private void checkBoxCableHankMeterage_Unchecked(object sender, RoutedEventArgs e)
        {
            if(checkBoxCableHankMeterage.IsChecked == false)
            {
                numericUpDownCableHankMeterage.Value = null;
                expanderCableHankMeterageStandartValues.IsExpanded = false;
            }
        }
    }
}
