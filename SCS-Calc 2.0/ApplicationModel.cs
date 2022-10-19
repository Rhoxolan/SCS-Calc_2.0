using SCSCalc;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace SCS_Calc_2._0
{
    public class ApplicationModel
    {
        private ObservableCollection<Configuration> configurations;
        private string settingsDocPath;
        private SCSCalcParameters parameters;

        public ApplicationModel()
        {
            configurations = new();
            Configurations = new(configurations);
            settingsDocPath = "SCS-CalcParametersData.json";
            Loader();
        }

        public ReadOnlyObservableCollection<Configuration> Configurations { get; }

        public (
            (decimal Min, decimal Max) MinPermanentLinkDiapason,
            (decimal Min, decimal Max) MaxPermanentLinkDiapason,
            (decimal Min, decimal Max) NumberOfPortsDiapason,
            (decimal Min, decimal Max) NumberOfWorkplacesDiapason,
            (decimal Min, decimal Max) CableHankMeterageDiapason,
            (decimal Min, decimal Max) TechnologicalReserveDiapason
            )
            Diapasons
        {
            get
            {
                return parameters.Diapasons;
            }
        }

        public void СalculateConfiguration(double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces,
            int numberOfPorts, double? cableHankMeterage)
        {

        }

        private void Loader() //Метод для загрузки параметров расчёта конфигураций
        {
            if (File.Exists(settingsDocPath))
            {
                try
                {
                    parameters = SCSCalcParameters.ParametersDeserializer(settingsDocPath);
                }
                catch (Exception ex)
                {
                    Task.Run(() => MessageBox.Show($"Ошибка считывания настроек параметров расчёта конфигураций:{Environment.NewLine}{ex.Message}{Environment.NewLine}" +
                        $"Настройки сброшены до стандартных значений.", "Внимание!",
                        MessageBoxButton.OK, MessageBoxImage.Warning));
                    parameters = new();
                    parameters.SetStrictСomplianceWithTheStandart();
                    parameters.SetAnArbitraryNumberOfPorts();
                    parameters.SetTechnologicalReserveAvailability();
                    parameters.SetNonRecommendations();
                    SCSCalcParameters.ParametersSerializer(parameters, settingsDocPath);
                }
            }
            else
            {
                //Первичная настройка
                parameters = new();
                parameters.SetStrictСomplianceWithTheStandart();
                parameters.SetAnArbitraryNumberOfPorts();
                parameters.SetTechnologicalReserveAvailability();
                parameters.SetNonRecommendations();
                SCSCalcParameters.ParametersSerializer(parameters, settingsDocPath);
            }
        }
    }
}
