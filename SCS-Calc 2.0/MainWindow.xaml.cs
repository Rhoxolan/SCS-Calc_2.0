using System.Windows;

namespace SCS_Calc_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = Resources["calculatePage"];
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = Resources["calculatePage"];
        }

        private void InformationButton_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = Resources["informationPage"];
        }

        private void AdvancedParametersButton_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = Resources["advancedParametersPage"];
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = Resources["historyPage"];
        }
    }
}
