using System.Windows.Controls;

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

        private void checkBoxCableHankMeterage_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            expanderCableHankMeterageStandartValues.IsExpanded = false;
        }
    }
}
