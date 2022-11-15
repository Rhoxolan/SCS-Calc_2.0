using SCSCalc;
using SCSCalc.Parameters;
using System;
using System.Collections.ObjectModel;

namespace SCS_Calc_2._0
{
    public class ApplicationModel
    {
        private ObservableCollection<Configuration> configurations;
        private SCSCalcParameters parameters;
        private ConfigurationCalculateParameters calculateParameters;

        public ApplicationModel(
            Action<Configuration> SaveToTXTAction,
            Action<SCSCalcParameters> ParametersSerializeAction,
            Func<SCSCalcParameters?> ParametersDeserializeFunc,
            Func<ObservableCollection<Configuration>> ConfigurationDBLoadFunc,
            Func<SCSCalcParameters, ConfigurationCalculateParameters, double, double, int, int, double?, Configuration> СalculateConfigurationFunc,
            Func<bool> DeleteAllConfigurationsFunc,
            Func<Configuration, bool> DeleteConfigurationFunc,
            Func<bool> ResetParametersFunc
            )
        {
            this.SaveToTXTAction = SaveToTXTAction;
            this.ParametersSerializeAction = ParametersSerializeAction;
            this.ParametersDeserializeFunc = ParametersDeserializeFunc;
            this.ConfigurationDBLoadFunc = ConfigurationDBLoadFunc;
            this.СalculateConfigurationFunc = СalculateConfigurationFunc;
            this.DeleteAllConfigurationsFunc = DeleteAllConfigurationsFunc;
            this.DeleteConfigurationFunc = DeleteConfigurationFunc;
            this.ResetParametersFunc = ResetParametersFunc;
            configurations = this.ConfigurationDBLoadFunc();
            Configurations = new(configurations);
            parameters = this.ParametersDeserializeFunc()!;
            if (parameters == null)
            {
                parameters = new()
                {
                    IsStrictСomplianceWithTheStandart = true,
                    IsAnArbitraryNumberOfPorts = true,
                    IsTechnologicalReserveAvailability = true,
                    IsRecommendationsAvailability = false
                };
                ParametersSerializeAction(parameters);
            }
            calculateParameters = new();
        }

        //Изменение параметров расчёта конфигураций СКС
        public event Action? ParametersChanged;

        //Изменение значения даипазонов вводимых параметров расчёта конфигураций СКС
        public event Action? DiapasonsChanged;

        //Изменение значения коэффициента технологического запаса
        public event Action? TechnologicalReserveChanged;

        //Изменение значения аргументов получения рекомендаций по побдору кабеля
        public event Action? RecommendationsArgumentsChanged;

        //Сохранение конфигурации в текстовый документ
        private event Action<Configuration> SaveToTXTAction;

        //Сериализация настраеваемых параметров расчёта конфигураций СКС
        private event Action<SCSCalcParameters> ParametersSerializeAction;

        //Десериализация настраеваемых параметров расчёта конфигураций СКС
        private event Func<SCSCalcParameters?> ParametersDeserializeFunc;

        //Удаление всех записей конфигураций СКС
        private event Func<bool> DeleteAllConfigurationsFunc;

        //Загрузка БД конфигураций СКС
        private event Func<ObservableCollection<Configuration>> ConfigurationDBLoadFunc;

        //Расчет конфигурации СКС и сохранение данных в БД
        private event Func<SCSCalcParameters, ConfigurationCalculateParameters, double, double, int, int, double?, Configuration> СalculateConfigurationFunc;

        //Удаление записи конфигурации
        private event Func<Configuration, bool> DeleteConfigurationFunc;

        //Сброс настраиваемых параметров приложения до заводских
        private event Func<bool> ResetParametersFunc;

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
                ParametersSerializeAction(parameters);
                TechnologicalReserveChanged?.Invoke();
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
                ParametersSerializeAction(parameters);
                RecommendationsArgumentsChanged?.Invoke();
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
                ParametersSerializeAction(parameters);
                RecommendationsArgumentsChanged?.Invoke();
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
                ParametersSerializeAction(parameters);
                RecommendationsArgumentsChanged?.Invoke();
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
                ParametersSerializeAction(parameters);
                RecommendationsArgumentsChanged?.Invoke();
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
                ParametersSerializeAction(parameters);
                ParametersChanged?.Invoke();
                DiapasonsChanged?.Invoke();
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
                ParametersSerializeAction(parameters);
                ParametersChanged?.Invoke();
                RecommendationsArgumentsChanged?.Invoke();
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
                ParametersSerializeAction(parameters);
                ParametersChanged?.Invoke();
                DiapasonsChanged?.Invoke();
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
                ParametersSerializeAction(parameters);
                ParametersChanged?.Invoke();
                TechnologicalReserveChanged?.Invoke();
            }
        }

        public bool? IsCableHankMeterageAvailability
        {
            set => calculateParameters.IsCableHankMeterageAvailability = value;
        }

        public void СalculateConfiguration(double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces, int numberOfPorts, double? cableHankMeterage) 
            => configurations.Add(СalculateConfigurationFunc(parameters, calculateParameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts, cableHankMeterage));   

        public void DeleteAllConfigurations()
        {
            if (DeleteAllConfigurationsFunc())
            {
                configurations.Clear();
            }
        }

        public void DeleteConfiguration(Configuration configuration)
        {
            if(DeleteConfigurationFunc(configuration))
            {
                configurations.Remove(configuration);
            }
        }

        public void SaveToTXT(Configuration configuration) => SaveToTXTAction(configuration);

        public void SetDefaultsParameters()
        {
            if (ResetParametersFunc())
            {
                IsStrictСomplianceWithTheStandart = true;
                IsAnArbitraryNumberOfPorts = true;
                IsTechnologicalReserveAvailability = true;
                IsRecommendationsAvailability = false;
            }
        }
    }
}
