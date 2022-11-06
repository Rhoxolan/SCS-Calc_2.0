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

        public ApplicationModel(Action<Configuration>? saveToTXTAction, Action<SCSCalcParameters>? parametersSerializeAction, Func<SCSCalcParameters>? parametersDeserializeFunc,
            Func<ObservableCollection<Configuration>> сonfigurationDBLoadFunc, Action<SCSCalcParameters, double, double, int, int, double?> calculateConfigurationAction,
            Action deleteAllConfigurationsAction, Action<Configuration> deleteConfigurationAction)
        {
            SaveToTXTAction = saveToTXTAction;
            ParametersSerializeAction = parametersSerializeAction;
            ParametersDeserializeFunc = parametersDeserializeFunc;
            ConfigurationDBLoadFunc = сonfigurationDBLoadFunc;
            СalculateConfigurationAction = calculateConfigurationAction;
            DeleteAllConfigurationsAction = deleteAllConfigurationsAction;
            DeleteConfigurationAction = deleteConfigurationAction;
            configurations = ConfigurationDBLoadFunc.Invoke();
            Configurations = new(configurations);
            parameters = ParametersDeserializeFunc?.Invoke()!;
            if (parameters == null)
            {
                parameters = new()
                {
                    IsStrictСomplianceWithTheStandart = true,
                    IsAnArbitraryNumberOfPorts = true,
                    IsTechnologicalReserveAvailability = true,
                    IsRecommendationsAvailability = false
                };
                ParametersSerializeAction?.Invoke(parameters);
            }
        }

        //Изменение параметров расчёта конфигураций СКС
        public event EventHandler? ParametersChanged;

        //Изменение значения даипазонов вводимых параметров расчёта конфигураций СКС
        public event EventHandler? DiapasonsChanged;

        //Изменение значения коэффициента технологического запаса
        public event EventHandler? TechnologicalReserveChanged;

        //Изменение значения аргументов получения рекомендаций по побдору кабеля
        public event EventHandler? RecommendationsArgumentsChanged;

        //Сохранение конфигурации в текстовый документ
        private event Action<Configuration>? SaveToTXTAction;

        //Сериализация настраеваемых параметров расчёта конфигураций СКС
        private event Action<SCSCalcParameters>? ParametersSerializeAction;

        //Десериализация настраеваемых параметров расчёта конфигураций СКС
        private event Func<SCSCalcParameters>? ParametersDeserializeFunc;

        //Загрузка БД конфигураций СКС
        private event Func<ObservableCollection<Configuration>> ConfigurationDBLoadFunc;

        //Расчет конфигурации СКС и сохранение данных в БД
        private event Action<SCSCalcParameters, double, double, int, int, double?> СalculateConfigurationAction;

        //Удаление всех записей конфигураций СКС
        private event Action DeleteAllConfigurationsAction;

        //Удаление записи конфигурации
        private event Action<Configuration> DeleteConfigurationAction;

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
                ParametersSerializeAction?.Invoke(parameters);
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
                ParametersSerializeAction?.Invoke(parameters);
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
                ParametersSerializeAction?.Invoke(parameters);
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
                ParametersSerializeAction?.Invoke(parameters);
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
                ParametersSerializeAction?.Invoke(parameters);
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
                ParametersSerializeAction?.Invoke(parameters);
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
                ParametersSerializeAction?.Invoke(parameters);
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
                ParametersSerializeAction?.Invoke(parameters);
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
                ParametersSerializeAction?.Invoke(parameters);
                ParametersChanged?.Invoke(null!, null!);
                TechnologicalReserveChanged?.Invoke(null!, null!);
            }
        }

        public void СalculateConfiguration(double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces,
            int numberOfPorts, double? cableHankMeterage) => СalculateConfigurationAction(parameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces,
                numberOfPorts, cableHankMeterage);

        public void DeleteAllConfigurations() => DeleteAllConfigurationsAction();

        public void DeleteConfiguration(Configuration configuration) => DeleteConfigurationAction(configuration);

        public void SaveToTXT(Configuration configuration) => SaveToTXTAction?.Invoke(configuration);

        //Сброс до заводских параметров расчёта конфигураций скс
        public void SetDefaultsParameters()
        {
            IsStrictСomplianceWithTheStandart = true;
            IsAnArbitraryNumberOfPorts = true;
            IsTechnologicalReserveAvailability = true;
            IsRecommendationsAvailability = false;
        }
    }
}
