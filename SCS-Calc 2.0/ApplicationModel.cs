using SCSCalc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace SCS_Calc_2._0
{
    public partial class ApplicationModel
    {
        private ObservableCollection<Configuration> configurations;
        private string settingsDocPath;
        private SCSCalcParameters parameters;
        private List<string> initializeExceptions;

        public ApplicationModel()
        {
            configurations = new();
            Configurations = new(configurations);
            settingsDocPath = "SCS-CalcParametersData.json";
            initializeExceptions = new();
            Loader();
        }

        public string[] InitializeExceptions
        {
            get
            {
                return initializeExceptions.ToArray();
            }
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

        //Изменение значения даипазонов вводимых параметров расчёта конфигураций
        public event EventHandler DiapasonsChanged;

        //Метод для загрузки параметров расчёта конфигураций
        private void Loader()
        {
            if (File.Exists(settingsDocPath))
            {
                try
                {
                    parameters = SCSCalcParameters.ParametersDeserializer(settingsDocPath);
                }
                catch (Exception ex)
                {
                    initializeExceptions.Add($"Ошибка считывания настроек параметров расчёта конфигураций:{Environment.NewLine}{ex.Message}{Environment.NewLine}");
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
