using Microsoft.EntityFrameworkCore;
using SCSCalc;
using SCSCalc.Parameters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace SCS_Calc_2._0
{
    public class ApplicationModel
    {
        ApplicationContext applicationContext;
        private ObservableCollection<Configuration> configurations;
        private string settingsDocPath;
        private Parameters parameters;
        private List<string> initializeExceptions;

        public ApplicationModel()
        {
            settingsDocPath = "SCS-CalcParametersData.json";
            initializeExceptions = new();
            applicationContext = new();
            applicationContext.Database.EnsureCreated();
            applicationContext.Configurations.Load();
            configurations = applicationContext.Configurations.Local.ToObservableCollection();
            Configurations = new(configurations);
            Loader();
        }

        //Изменение параметров расчёта конфигураций СКС
        public event EventHandler? ParametersChanged;

        //Изменение значения даипазонов вводимых параметров расчёта конфигураций СКС
        public event EventHandler? DiapasonsChanged;

        //Изменение значения коэффициента технологического запаса
        public event EventHandler? TechnologicalReserveChanged;

        //Изменение значения аргументов получения рекомендаций по побдору кабеля
        public event EventHandler? RecommendationsArgumentsChanged;

        //Возникновение ошибок в работе модели
        public event Action<string>? ModelExceptionOccurrence;

        //Ошибки, произошедшие при инициализации модели
        public string[] InitializeExceptions
        {
            get
            {
                return initializeExceptions.ToArray();
            }
        }

        public ReadOnlyObservableCollection<Configuration> Configurations { get; }

        public double TechnologicalReserve
        {
            get
            {
                return parameters.TechnologicalReserve;
            }
            set
            {
                parameters.TechnologicalReserve = value;
                Parameters.ParametersSerializer(parameters, settingsDocPath);
                TechnologicalReserveChanged?.Invoke(null!, null!);
            }
        }

        public IsolationType IsolationType
        {
            get
            {
                return parameters.RecommendationsArguments.IsolationType;
            }
            set
            {
                if (parameters.RecommendationsArguments.IsolationType == IsolationType.Indoor)
                {
                    parameters.RecommendationsArguments.IsolationType = IsolationType.Outdoor;
                }
                else
                {
                    parameters.RecommendationsArguments.IsolationType = IsolationType.Indoor;
                }
                Parameters.ParametersSerializer(parameters, settingsDocPath);
                RecommendationsArgumentsChanged?.Invoke(null!, null!);
            }
        }

        public IsolationMaterial IsolationMaterial
        {
            get
            {
                return parameters.RecommendationsArguments.IsolationMaterial;
            }
            set
            {
                if (parameters.RecommendationsArguments.IsolationMaterial == IsolationMaterial.PVC)
                {
                    parameters.RecommendationsArguments.IsolationMaterial = IsolationMaterial.LSZH;
                }
                else
                {
                    parameters.RecommendationsArguments.IsolationMaterial = IsolationMaterial.PVC;
                }
                Parameters.ParametersSerializer(parameters, settingsDocPath);
                RecommendationsArgumentsChanged?.Invoke(null!, null!);
            }
        }

        public ShieldedType ShieldedType
        {
            get
            {
                return parameters.RecommendationsArguments.ShieldedType;
            }
            set
            {
                if (parameters.RecommendationsArguments.ShieldedType == ShieldedType.UTP)
                {
                    parameters.RecommendationsArguments.ShieldedType = ShieldedType.FTP;
                }
                else
                {
                    parameters.RecommendationsArguments.ShieldedType = ShieldedType.UTP;
                }
                Parameters.ParametersSerializer(parameters, settingsDocPath);
                RecommendationsArgumentsChanged?.Invoke(null!, null!);
            }
        }

        public object ConnectionInterfaceStandard
        {
            get
            {
                return parameters.RecommendationsArguments.ConnectionInterfaces;
            }
            set
            {
                if (parameters.RecommendationsArguments.ConnectionInterfaces.Contains((ConnectionInterfaceStandard)value))
                {
                    parameters.RecommendationsArguments.ConnectionInterfaces.Remove((ConnectionInterfaceStandard)value);
                }
                else
                {
                    parameters.RecommendationsArguments.ConnectionInterfaces.Add((ConnectionInterfaceStandard)value);
                }
                Parameters.ParametersSerializer(parameters, settingsDocPath);
                RecommendationsArgumentsChanged?.Invoke(null!, null!);
            }
        }

        public SCSCalcDiapasons Diapasons
        {
            get => parameters.Diapasons;
        }

        public bool? IsStrictСomplianceWithTheStandart
        {
            get
            {
                return parameters.IsStrictСomplianceWithTheStandart;
            }
            set
            {
                parameters.IsStrictСomplianceWithTheStandart = value;
                Parameters.ParametersSerializer(parameters, settingsDocPath);
                ParametersChanged?.Invoke(null!, null!);
                DiapasonsChanged?.Invoke(null!, null!);
            }
        }

        public bool? IsRecommendationsAvailability
        {
            get
            {
                return parameters.IsRecommendationsAvailability;
            }
            set
            {
                parameters.IsRecommendationsAvailability = value;
                Parameters.ParametersSerializer(parameters, settingsDocPath);
                ParametersChanged?.Invoke(null!, null!);
                RecommendationsArgumentsChanged?.Invoke(null!, null!);
            }
        }

        public bool? IsAnArbitraryNumberOfPorts
        {
            get
            {
                return parameters.IsAnArbitraryNumberOfPorts;
            }
            set
            {
                parameters.IsAnArbitraryNumberOfPorts = value;
                Parameters.ParametersSerializer(parameters, settingsDocPath);
                ParametersChanged?.Invoke(null!, null!);
                DiapasonsChanged?.Invoke(null!, null!);
            }
        }

        public bool? IsTechnologicalReserveAvailability
        {
            get
            {
                return parameters.IsTechnologicalReserveAvailability;
            }
            set
            {
                parameters.IsTechnologicalReserveAvailability = value;
                Parameters.ParametersSerializer(parameters, settingsDocPath);
                ParametersChanged?.Invoke(null!, null!);
                TechnologicalReserveChanged?.Invoke(null!, null!);
            }
        }

        public void СalculateConfiguration(double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces,
            int numberOfPorts, double? cableHankMeterage)
        {
            applicationContext.Configurations.Add(Configuration.Calculate(parameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts, cableHankMeterage));
            DBSaveChangesAsync();
        }

        public void DeleteAllConfigurations()
        {
            applicationContext.RemoveRange(applicationContext.Configurations);
            DBSaveChangesAsync();
        }

        public void DeleteConfiguration(Configuration configuration)
        {
            applicationContext.Configurations.Remove(configuration);
            DBSaveChangesAsync();
        }

        //Сброс до заводских параметров расчёта конфигураций скс
        public void SetDefaultsParameters()
        {
            IsStrictСomplianceWithTheStandart = true;
            IsAnArbitraryNumberOfPorts = true;
            IsTechnologicalReserveAvailability = true;
            IsRecommendationsAvailability = false;
        }

        //Сохранение данных в БД
        private async void DBSaveChangesAsync()
        {
            try
            {
                await applicationContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelExceptionOccurrence?.Invoke($"Ошибка сохранения данных:{Environment.NewLine}{ex.Message}");
            }
        }

        //Метод для загрузки параметров расчёта конфигураций СКС
        private void Loader()
        {
            if (File.Exists(settingsDocPath))
            {
                try
                {
                    parameters = Parameters.ParametersDeserializer(settingsDocPath);
                }
                catch (Exception ex)
                {
                    initializeExceptions.Add($"Ошибка считывания настроек параметров расчёта конфигураций:{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                    parameters = new()
                    {
                        IsStrictСomplianceWithTheStandart = true,
                        IsAnArbitraryNumberOfPorts = true,
                        IsTechnologicalReserveAvailability = true,
                        IsRecommendationsAvailability = false
                    };
                    Parameters.ParametersSerializer(parameters, settingsDocPath);
                }
            }
            else
            {
                //Первичная настройка
                parameters = new()
                {
                    IsStrictСomplianceWithTheStandart = true,
                    IsAnArbitraryNumberOfPorts = true,
                    IsTechnologicalReserveAvailability = true,
                    IsRecommendationsAvailability = false
                };
                Parameters.ParametersSerializer(parameters, settingsDocPath);
            }
        }
    }
}
