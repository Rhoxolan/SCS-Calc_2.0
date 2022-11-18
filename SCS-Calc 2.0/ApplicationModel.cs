using SCSCalc;
using SCSCalc.Parameters;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SCS_Calc_2._0
{
    public class ApplicationModel
    {
        private ObservableCollection<Configuration> configurations;
        private SCSCalcParameters parameters;
        private ConfigurationCalculateParameters calculateParameters;

        //Сохранение конфигурации в текстовый документ
        private event Action<Configuration> SaveToTXTAction;

        //Сохранение настраеваемых параметров расчёта конфигураций СКС
        private event Action<SCSCalcParameters> ParametersSaveAction;

        //Загрузка настраеваемых параметров расчёта конфигураций СКС
        private event Func<SCSCalcParameters?> ParametersLoadFunc;

        //Удаление всех записей конфигураций СКС
        private event Func<Task<bool>> DeleteAllConfigurationsFuncAsync;

        //Загрузка БД конфигураций СКС
        private event Func<ObservableCollection<Configuration>> ConfigurationsLoadFunc;

        //Расчет конфигурации СКС и сохранение данных в БД
        private event Func<SCSCalcParameters, ConfigurationCalculateParameters, double, double, int, int, double?, Task<Configuration>> СalculateConfigurationFuncAsync;

        //Удаление записи конфигурации
        private event Func<Configuration, Task<bool>> DeleteConfigurationFuncAsync;

        //Сброс настраиваемых параметров приложения до заводских
        private event Func<bool> ResetParametersFunc;

        public ApplicationModel(
            Action<Configuration> SaveToTXTAction,
            Action<SCSCalcParameters> ParametersSaveAction,
            Func<SCSCalcParameters?> ParametersLoadFunc,
            Func<ObservableCollection<Configuration>> ConfigurationsLoadFunc,
            Func<SCSCalcParameters, ConfigurationCalculateParameters, double, double, int, int, double?, Task<Configuration>> СalculateConfigurationFuncAsync,
            Func<Task<bool>> DeleteAllConfigurationsFuncAsync,
            Func<Configuration, Task<bool>> DeleteConfigurationFuncAsync,
            Func<bool> ResetParametersFunc
            )
        {
            this.SaveToTXTAction = SaveToTXTAction;
            this.ParametersSaveAction = ParametersSaveAction;
            this.ParametersLoadFunc = ParametersLoadFunc;
            this.ConfigurationsLoadFunc = ConfigurationsLoadFunc;
            this.СalculateConfigurationFuncAsync = СalculateConfigurationFuncAsync;
            this.DeleteAllConfigurationsFuncAsync = DeleteAllConfigurationsFuncAsync;
            this.DeleteConfigurationFuncAsync = DeleteConfigurationFuncAsync;
            this.ResetParametersFunc = ResetParametersFunc;

            configurations = this.ConfigurationsLoadFunc();
            Configurations = new(configurations);
            parameters = this.ParametersLoadFunc()!;
            if (parameters == null)
            {
                parameters = new()
                {
                    IsStrictСomplianceWithTheStandart = true,
                    IsAnArbitraryNumberOfPorts = true,
                    IsTechnologicalReserveAvailability = true,
                    IsRecommendationsAvailability = false
                };
                this.ParametersSaveAction(parameters);
            }
            calculateParameters = new();
        }

        /// <summary>
        /// Изменение параметров расчёта конфигураций СКС
        /// </summary>
        public event Action? ParametersChanged;

        //Изменение значения даипазонов вводимых параметров расчёта конфигураций СКС
        public event Action? DiapasonsChanged;

        //Изменение значения коэффициента технологического запаса
        public event Action? TechnologicalReserveChanged;

        //Изменение значения аргументов получения рекомендаций по побдору кабеля
        public event Action? RecommendationsArgumentsChanged;

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
                ParametersSaveAction(parameters);
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
                ParametersSaveAction(parameters);
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
                ParametersSaveAction(parameters);
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
                ParametersSaveAction(parameters);
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
                ParametersSaveAction(parameters);
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
                ParametersSaveAction(parameters);
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
                ParametersSaveAction(parameters);
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
                ParametersSaveAction(parameters);
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
                ParametersSaveAction(parameters);
                ParametersChanged?.Invoke();
                TechnologicalReserveChanged?.Invoke();
            }
        }

        public bool? IsCableHankMeterageAvailability
        {
            set => calculateParameters.IsCableHankMeterageAvailability = value;
        }

        public async Task СalculateConfigurationAsync(double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces, int numberOfPorts, double? cableHankMeterage)
            => configurations.Add(
                await СalculateConfigurationFuncAsync(parameters, calculateParameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts, cableHankMeterage));


        public async Task DeleteAllConfigurationsAsync()
        {
            if (await DeleteAllConfigurationsFuncAsync())
            {
                configurations.Clear();
            }
        }

        public async Task DeleteConfigurationAsync(Configuration configuration)
        {
            if (await DeleteConfigurationFuncAsync(configuration))
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
