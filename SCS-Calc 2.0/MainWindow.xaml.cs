using System.Windows;

namespace SCS_Calc_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculateControl calculatePage;
        private InformationControl informationPage;
        private AdvancedParametersControl advancedParametersPage;
        private HistoryControl historyPage;

        public MainWindow()
        {
            InitializeComponent();
            calculatePage = new();
            informationPage = new();
            advancedParametersPage = new();
            historyPage = new();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => controlsContentControl.Content = calculatePage;

        private void CalculateButton_Click(object sender, RoutedEventArgs e) => controlsContentControl.Content = calculatePage;

        private void InformationButton_Click(object sender, RoutedEventArgs e) => controlsContentControl.Content = informationPage;

        private void AdvancedParametersButton_Click(object sender, RoutedEventArgs e) => controlsContentControl.Content = advancedParametersPage;

        private void HistoryButton_Click(object sender, RoutedEventArgs e) => controlsContentControl.Content = historyPage;
    }
}
