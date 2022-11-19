using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using SCSCalc;
using SCSCalc.Parameters;

namespace SCS_Calc_2._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private SplashScreen splashScreen = new("SplashScreen.png");
        private ManualResetEvent waitHandle = new(false);
        private System.Threading.Timer timer;
        private readonly ApplicationModel applicationModel;
        private readonly HistoryPageViewModel historyPageViewModel;
        private readonly CalculatePageViewModel calculatePageViewModel;
        private readonly AdvancedParametersPageViewModel advancedParametersPageViewModel;
        private string parametersDocPath = "SCS-CalcParametersData.json";
        private List<string> initializeExceptions = new();

        public App()
        {
            splashScreen.Show(false);
            TimerCallback timerCallback = (s) => {
                waitHandle.Set();
                timer!.Dispose();
            };
            timer = new Timer(timerCallback, default, 2075, 0); //Таймер для минимального времени отображения экрана-заставки
            applicationModel = new(
                SaveToTXTAction: SaveToTXT,
                ParametersSaveAction: ParametersSerialize,
                ParametersLoadFunc: ParametersDeserialize,
                ConfigurationsLoadFunc: ConfigurationDBLoad,
                СalculateConfigurationFuncAsync: СalculateConfigurationAsync,
                DeleteAllConfigurationsFuncAsync: DeleteAllConfigurationsAsync,
                DeleteConfigurationFuncAsync: DeleteConfigurationAsync,
                ResetParametersFunc: ResetParametersСonfirm
                );
            historyPageViewModel = new(applicationModel);
            calculatePageViewModel = new(applicationModel);
            advancedParametersPageViewModel = new(applicationModel);
            this.Startup += Application_Startup;
            this.Activated += App_Activated;
            this.ExceptionOccurrenceAction += ExceptionOccurrence;
        }

        //Возникновение ошибок в логике приложения
        private Action<string>? ExceptionOccurrenceAction;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Resources["historyPageViewModel"] = historyPageViewModel;
            Resources["calculatePageViewModel"] = calculatePageViewModel;
            Resources["advancedParametersPageViewModel"] = advancedParametersPageViewModel;
            waitHandle.WaitOne(); //Ожидание завершения минимального времени для отображения экрана-заставки.
            splashScreen.Close(new(0, 0, 0, 0, 500));
        }

        private void App_Activated(object? sender, EventArgs e)
        {
            if (initializeExceptions.Count > 0)
            {
                StringBuilder stringBuilder = new();
                stringBuilder.AppendLine($"Внимание! При запуске приложения SCS-Calc 2.0 произошли следующие ошибки:{Environment.NewLine}");
                foreach (var exception in initializeExceptions)
                {
                    stringBuilder.AppendLine(exception);
                }
                MessageBox.Show(stringBuilder.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            (sender as Application)!.Activated -= App_Activated;
        }

        //Сохранение конфигурации в текстовый документ
        private void SaveToTXT(Configuration configuration)
        {
            StringBuilder saveStringBuilder = new();
            saveStringBuilder.AppendLine("Конфигурация создана в приложении SCS-Calc 2.0");
            saveStringBuilder.AppendLine();
            saveStringBuilder.AppendLine();
            saveStringBuilder.AppendLine($"Дата и время записи конфигурации СКС: {configuration.RecordTime.ToShortDateString()} " +
                    $"{configuration.RecordTime.ToLongTimeString()}");
            saveStringBuilder.AppendLine($"Наименьшая длина постоянного линка: {configuration.MinPermanentLink} м.");
            saveStringBuilder.AppendLine($"Наибольшая длина постоянного линка: {configuration.MaxPermanentLink} м.");
            saveStringBuilder.AppendLine($"Средняя длина постоянного линка: {configuration.AveragePermanentLink} м.");
            saveStringBuilder.AppendLine($"Количество рабочих мест: {configuration.NumberOfWorkplaces}");
            saveStringBuilder.AppendLine($"Количество портов на 1 рабочее место: {configuration.NumberOfPorts}");
            if (configuration.CableHankMeterage != null)
            {
                saveStringBuilder.AppendLine($"Количество портов на 1 рабочее место: {configuration.NumberOfPorts}");
                saveStringBuilder.AppendLine($"Метраж кабеля в 1-й бухте: {configuration.CableHankMeterage}");
                saveStringBuilder.AppendLine($"Необходимое количество бухт кабеля: {configuration.HankQuantity}");
            }
            saveStringBuilder.AppendLine($"Итоговое необходимое количество кабеля: {configuration.TotalСableQuantity} м.");
            if (!String.IsNullOrEmpty(configuration.Recommendations))
            {
                saveStringBuilder.AppendLine();
                saveStringBuilder.AppendLine("Рекомендации по подбору кабеля:");
                saveStringBuilder.AppendLine(configuration.Recommendations);
            }
            string? saveString = saveStringBuilder.ToString();
            SaveFileDialog sfd = new()
            {
                Filter = "Текстовые документы(*.txt)|*.txt",
                FileName = $"Конфигурация СКС {configuration.RecordTime.ToShortDateString()} " +
                $"{configuration.RecordTime.Hour:00}.{configuration.RecordTime.Minute:00}." +
                $"{configuration.RecordTime.Second:00}.txt"
            };
            if (Equals(sfd.ShowDialog(), true))
            {
                using FileStream fs = new(sfd.FileName, FileMode.Create);
                using StreamWriter sw = new(fs);
                sw.WriteLine(saveString);
            }
        }

        //Сериализация настраеваемых параметров расчёта конфигураций СКС
        private void ParametersSerialize(SCSCalcParameters actualParameters)
        {
            (bool? IsStrictСomplianceWithTheStandart,
                bool? IsAnArbitraryNumberOfPorts,
                bool? IsTechnologicalReserveAvailability,
                bool? IsRecommendationsAvailability,
                double TechnologicalReserve,
                RecommendationsArguments RecommendationsArguments) parameters = new()
                {
                    IsStrictСomplianceWithTheStandart = actualParameters.IsStrictСomplianceWithTheStandart,
                    IsAnArbitraryNumberOfPorts = actualParameters.IsAnArbitraryNumberOfPorts,
                    IsTechnologicalReserveAvailability = actualParameters.IsTechnologicalReserveAvailability,
                    IsRecommendationsAvailability = actualParameters.IsRecommendationsAvailability,
                    TechnologicalReserve = actualParameters.TechnologicalReserve,
                    RecommendationsArguments = actualParameters.RecommendationsArguments
                };
            using FileStream fs = new(parametersDocPath, FileMode.Create);
            JsonSerializerOptions options = new()
            {
                IncludeFields = true
            };
            JsonSerializer.Serialize(fs, parameters, options);
        }

        //Десериализация настраеваемых параметров расчёта конфигураций СКС
        private SCSCalcParameters? ParametersDeserialize()
        {
            if (!File.Exists(parametersDocPath))
            {
                return null;
            }
            try
            {
                (bool? IsStrictСomplianceWithTheStandart,
                    bool? IsAnArbitraryNumberOfPorts,
                    bool? IsTechnologicalReserveAvailability,
                    bool? IsRecommendationsAvailability,
                    double TechnologicalReserve,
                    RecommendationsArguments RecommendationsArguments) parameters;
                SCSCalcParameters parametersPresent = new();
                using FileStream fs = new(parametersDocPath, FileMode.Open);
                JsonSerializerOptions options = new()
                {
                    IncludeFields = true
                };
                parameters = JsonSerializer.Deserialize<(bool?, bool?, bool?, bool?, double, RecommendationsArguments)>(fs, options);
                parametersPresent.IsStrictСomplianceWithTheStandart = parameters.IsStrictСomplianceWithTheStandart;
                parametersPresent.IsAnArbitraryNumberOfPorts = parameters.IsAnArbitraryNumberOfPorts;
                if (Equals(parameters.IsTechnologicalReserveAvailability, true))
                {
                    parametersPresent.IsTechnologicalReserveAvailability = true;
                    parametersPresent.TechnologicalReserve = parameters.TechnologicalReserve;
                }
                else
                {
                    parametersPresent.IsTechnologicalReserveAvailability = false;
                }
                if (Equals(parameters.IsRecommendationsAvailability, true))
                {
                    parametersPresent.IsRecommendationsAvailability = true;
                    parametersPresent.RecommendationsArguments.IsolationType = parameters.RecommendationsArguments.IsolationType;
                    parametersPresent.RecommendationsArguments.IsolationMaterial = parameters.RecommendationsArguments.IsolationMaterial;
                    parametersPresent.RecommendationsArguments.ConnectionInterfaces = parameters.RecommendationsArguments.ConnectionInterfaces;
                    parametersPresent.RecommendationsArguments.ShieldedType = parameters.RecommendationsArguments.ShieldedType;
                }
                else
                {
                    parametersPresent.IsRecommendationsAvailability = false;
                }
                return parametersPresent;
            }
            catch (Exception ex)
            {
                initializeExceptions.Add($"Ошибка считывания настроек параметров расчёта конфигураций:{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                return null;
            }
        }

        //Загрузка БД конфигураций СКС
        private ObservableCollection<Configuration> ConfigurationDBLoad()
        {
            using ApplicationContext context= new();
            context.Database.EnsureCreated();
            context.Configurations.Load();
            return new ObservableCollection<Configuration>(context.Configurations.Local.ToObservableCollection());
        }

        //Расчет конфигурации СКС и сохранение данных в БД
        private async Task<Configuration> СalculateConfigurationAsync(SCSCalcParameters parameters, ConfigurationCalculateParameters calculateParameters, double minPermanentLink,
            double maxPermanentLink, int numberOfWorkplaces,int numberOfPorts, double? cableHankMeterage)
        {
            Configuration configuration = Configuration.Calculate(parameters, calculateParameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts, cableHankMeterage);
            using ApplicationContext context = new();
            await Task.Run(() => context.Configurations.Add(configuration)); //Синхронные методы используются из-за ограничений SQLite
            await Task.Run(() => DBSaveChanges(context));                    //https://learn.microsoft.com/ru-ru/dotnet/standard/data/sqlite/async
            return configuration;
        }

        //Удаление всех записей конфигураций СКС
        private async Task<bool> DeleteAllConfigurationsAsync()
        {
            using ApplicationContext context = new();
            if (MessageBox.Show($"Вы действительно хотите удалить ВСЕ конфигурации СКС? ({context.Configurations.Count()} конфигураций){Environment.NewLine}" +
                    $"Отменить это действие будет невозможно", "Удаление ВСЕХ конфигураций СКС", MessageBoxButton.YesNoCancel, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                context.Configurations.RemoveRange(context.Configurations);
                await Task.Run(() => DBSaveChanges(context)); //Синхронные методы используются из-за ограничений SQLite
                return true;                                  //https://learn.microsoft.com/ru-ru/dotnet/standard/data/sqlite/async
            }
            return false;
        }

        //Удаление записи конфигурации
        private async Task<bool> DeleteConfigurationAsync(Configuration configuration)
        {
            if (MessageBox.Show(
                    $"Вы действительно хотите удалить выбранную конфигурацию СКС?{Environment.NewLine}" +
                    $"({configuration.RecordTime.ToShortDateString()} {configuration.RecordTime.ToLongTimeString()}, " +
                    $"мин. - {configuration.MinPermanentLink:F0} м, макс. - {configuration.MaxPermanentLink:F0} м, всего - " +
                    $"{configuration.TotalСableQuantity:F0} м)",
                    "Удаление конфигурации СКС", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using ApplicationContext context = new();
                context.Configurations.Remove(configuration);
                await Task.Run(() => DBSaveChanges(context)); //Синхронные методы используются из-за ограничений SQLite
                return true;                                  //https://learn.microsoft.com/ru-ru/dotnet/standard/data/sqlite/async
            }
            return false;
        }

        //Подтверждение сброса настраиваемых параметров приложения до заводских
        private bool ResetParametersСonfirm()
        {
            return MessageBox.Show("Вы действительно хотите вернуть параметры по умолчанию?", "Внимание!",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        //Сохранение данных в БД
        private void DBSaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges(); //Синхронные методы используются из-за ограничений SQLite
            }                          //https://learn.microsoft.com/ru-ru/dotnet/standard/data/sqlite/async
            catch (Exception ex)
            {
                Dispatcher.Invoke(() => ExceptionOccurrenceAction?.Invoke($"Ошибка сохранения данных:{Environment.NewLine}{ex.Message}"));
            }
        }

        //Возникновение ошибок в логике приложения
        private void ExceptionOccurrence(string str)
        {
            MessageBox.Show(str, "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            if (MessageBox.Show("Продолжить выводить сообщения об ошибках в работе приложения?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                this.ExceptionOccurrenceAction -= ExceptionOccurrence;
            }
        }
    }

    file class ApplicationContext : DbContext
    {
        public DbSet<Configuration> Configurations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=configurations.db");
    }
}
