using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
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
        private readonly ApplicationModel applicationModel;
        private readonly HistoryPageViewModel historyPageViewModel;
        private readonly CalculatePageViewModel calculatePageViewModel;
        private readonly AdvancedParametersPageViewModel advancedParametersPageViewModel;
        private string parametersDocPath;
        private List<string> initializeExceptions;
        private ApplicationContext dBContext;

        public App()
        {
            dBContext = new();
            parametersDocPath = "SCS-CalcParametersData.json";
            initializeExceptions = new();
            applicationModel = new(SaveToTXT, ParametersSerialize, ParametersDeserialize, ConfigurationDBLoad, СalculateConfiguration, DeleteAllConfigurations, DeleteConfiguration);
            historyPageViewModel = new(applicationModel);
            calculatePageViewModel = new(applicationModel);
            advancedParametersPageViewModel = new(applicationModel);
            this.Startup += Application_Startup;
            this.Activated += App_Activated;
            this.ExceptionOccurrenceAction += ExceptionOccurrence;
        }

        //Возникновение ошибок в логике приложения
        private Action<string> ExceptionOccurrenceAction;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Resources["historyPageViewModel"] = historyPageViewModel;
            Resources["calculatePageViewModel"] = calculatePageViewModel;
            Resources["advancedParametersPageViewModel"] = advancedParametersPageViewModel;
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
        private SCSCalcParameters ParametersDeserialize()
        {
            if (!File.Exists(parametersDocPath))
            {
                return null!;
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
                return null!;
            }
        }

        //Загрузка БД конфигураций СКС
        private ObservableCollection<Configuration> ConfigurationDBLoad()
        {
            dBContext.Database.EnsureCreated();
            dBContext.Configurations.Load();
            return dBContext.Configurations.Local.ToObservableCollection();
        }

        //Расчет конфигурации СКС и сохранение данных в БД
        private void СalculateConfiguration(SCSCalcParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces,
            int numberOfPorts, double? cableHankMeterage)
        {
            dBContext.Configurations.Add(Configuration.Calculate(parameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts, cableHankMeterage));
            DBSaveChangesAsync();
        }

        //Удаление всех записей конфигураций СКС
        private void DeleteAllConfigurations()
        {
            dBContext.RemoveRange(dBContext.Configurations);
            DBSaveChangesAsync();
        }

        //Удаление записи конфигурации
        private void DeleteConfiguration(Configuration configuration)
        {
            dBContext.Configurations.Remove(configuration);
            DBSaveChangesAsync();
        }

        //Сохранение данных в БД
        private async void DBSaveChangesAsync()
        {
            try
            {
                await dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ExceptionOccurrenceAction?.Invoke($"Ошибка сохранения данных:{Environment.NewLine}{ex.Message}");
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
}
