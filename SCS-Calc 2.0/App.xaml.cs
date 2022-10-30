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
        private readonly HistoryPageViewModel historyPageViewModel;
        private readonly CalculatePageViewModel calculatePageViewModel;
        private readonly AdvancedParametersPageViewModel advancedParametersPageViewModel;

        public App()
        {
            applicationModel = new();
            historyPageViewModel = new(applicationModel);
            calculatePageViewModel = new(applicationModel);
            advancedParametersPageViewModel = new(applicationModel);
            this.Startup += Application_Startup;
            this.Activated += App_Activated;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Resources["historyPageViewModel"] = historyPageViewModel;
            Resources["calculatePageViewModel"] = calculatePageViewModel;
            Resources["advancedParametersPageViewModel"] = advancedParametersPageViewModel;
        }

        private void App_Activated(object? sender, EventArgs e)
        {
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
            (sender as Application)!.Activated -= App_Activated;
        }
    }
}
