using System.Diagnostics;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace SCS_Calc_2._0
{
    /// <summary>
    /// Логика взаимодействия для InformationPage.xaml
    /// </summary>
    public partial class InformationPage : Page
    {
        public InformationPage()
        {
            InitializeComponent();
        }

        private void LabelAuthor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                using Process process = new();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = "https://github.com/Rhoxolan";
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
