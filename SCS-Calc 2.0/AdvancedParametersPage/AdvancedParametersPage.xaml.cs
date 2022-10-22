using System.Windows;
using System.Windows.Controls;

namespace SCS_Calc_2._0
{
    /// <summary>
    /// Логика взаимодействия для AdvancedParametersPage.xaml
    /// </summary>
    public partial class AdvancedParametersPage : Page
    {
        public AdvancedParametersPage()
        {
            InitializeComponent();
        }

        private void checkBoxStrictСomplianceWithTheStandart_Unchecked(object sender, RoutedEventArgs e)
        {
            checkBoxAnArbitraryNumberOfPorts.IsChecked = true;
        }
    }
}
