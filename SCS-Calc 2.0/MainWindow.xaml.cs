using System.Windows;

namespace SCS_Calc_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculatePage calculatePage;

        public MainWindow()
        {
            InitializeComponent();
            calculatePage = new();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = calculatePage;
        }
    }
}
