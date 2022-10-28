using System;
using System.Text;
using System.Windows;

namespace SCS_Calc_2._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ApplicationModel applicationModel;
        private readonly InformationPageViewModel informationPageViewModel;
        private readonly HistoryPageViewModel historyPageViewModel;
        private readonly CalculatePageViewModel calculatePageViewModel;
        private readonly AdvancedParametersPageViewModel advancedParametersPageViewModel;

        public App()
        {
            applicationModel = new();
            informationPageViewModel = new(applicationModel);
            historyPageViewModel = new(applicationModel);
            calculatePageViewModel = new(applicationModel);
            advancedParametersPageViewModel = new(applicationModel);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Resources["informationPageViewModel"] = informationPageViewModel;
            Resources["historyPageViewModel"] = historyPageViewModel;
            Resources["calculatePageViewModel"] = calculatePageViewModel;
            Resources["advancedParametersPageViewModel"] = advancedParametersPageViewModel;

            if (applicationModel.InitializeExceptions.Length > 0)
            {
                StringBuilder stringBuilder = new();
                stringBuilder.AppendLine($"Внимание! При запуске приложения SCS-Calc 2.0 произошли следующие ошибки:{Environment.NewLine}");
                foreach (var exception in applicationModel.InitializeExceptions)
                {
                    stringBuilder.AppendLine(exception);
                }
                MessageBox.Show(stringBuilder.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
