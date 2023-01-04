using SCSCalc;
using SCSCalc.Calculate;
using SCSCalc.Parameters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SCSCalc_2_0
{
    public class ApplicationModel
    {
        private ObservableCollection<Configuration> configurations;
        private SCSCalcParameters parameters;
        private ConfigurationCalculateParameters calculateParameters;

        //Saving structured cabling configuration to text document
        private event Action<Configuration> SaveToTXTAction;

        //Saving configurable parameters of structured cabling configuration calculating
        private event Action<SCSCalcParameters> ParametersSaveAction;

        //Loading the configurable parameters of structured cabling configuration calculating
        private event Func<SCSCalcParameters?> ParametersLoadFunc;

        //Deletion the all structured cabling configuration records
        private event Func<Task<bool>> DeleteAllConfigurationsFuncAsync;

        //Loading the structured cabling configuration data base
        private event Func<ObservableCollection<Configuration>> ConfigurationsLoadFunc;

        //Calculating the structured cabling configuration and saving it to data base
        private event Func<SCSCalcParameters, ConfigurationCalculateParameters, double, double, int, int, double?, Task<Configuration>> СalculateConfigurationFuncAsync;

        //Deletion of structured cabling configuration record
        private event Func<Configuration, Task<bool>> DeleteConfigurationFuncAsync;

        //Reset to default parameters
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
                parameters = new SCSCalcParameters
                {
                    IsStrictСomplianceWithTheStandart = true,
                    IsAnArbitraryNumberOfPorts = true,
                    IsTechnologicalReserveAvailability = true,
                    IsRecommendationsAvailability = false,
                };
                parameters.RecommendationsArguments.IsolationType = IsolationType.Indoor;
                parameters.RecommendationsArguments.IsolationMaterial = IsolationMaterial.PVC;
                parameters.RecommendationsArguments.ShieldedType = ShieldedType.UTP;
                parameters.RecommendationsArguments.ConnectionInterfaces = new List<ConnectionInterfaceStandard>
                {
                    ConnectionInterfaceStandard.None
                };
                this.ParametersSaveAction(parameters);
            }
            calculateParameters = new();
        }

        // Изменение параметров расчёта конфигураций СКС
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
                parameters.RecommendationsArguments.IsolationType = value;
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
                parameters.RecommendationsArguments.IsolationMaterial = value;
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
                parameters.RecommendationsArguments.ShieldedType = value;
                ParametersSaveAction(parameters);
                RecommendationsArgumentsChanged?.Invoke();
            }
        }

        public List<ConnectionInterfaceStandard> ConnectionInterfaces
        {
            get
            {
                return parameters.RecommendationsArguments.ConnectionInterfaces;
            }
            set
            {
                parameters.RecommendationsArguments.ConnectionInterfaces = value;
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
                if (Equals(value, false))
                {
                    IsolationType = IsolationType.Indoor;
                    IsolationMaterial = IsolationMaterial.PVC;
                    ShieldedType = ShieldedType.UTP;
                    ConnectionInterfaces = new List<ConnectionInterfaceStandard>
                    {
                        ConnectionInterfaceStandard.None
                    };
                }
                RecommendationsArguments currentRecommendationsArguments = new RecommendationsArguments
                {
                    IsolationType = parameters.RecommendationsArguments.IsolationType,
                    IsolationMaterial = parameters.RecommendationsArguments.IsolationMaterial,
                    ConnectionInterfaces = parameters.RecommendationsArguments.ConnectionInterfaces,
                    ShieldedType = parameters.RecommendationsArguments.ShieldedType
                };
                parameters.IsRecommendationsAvailability = value;
                parameters.RecommendationsArguments.IsolationType = currentRecommendationsArguments.IsolationType;
                parameters.RecommendationsArguments.IsolationMaterial = currentRecommendationsArguments.IsolationMaterial;
                parameters.RecommendationsArguments.ConnectionInterfaces = currentRecommendationsArguments.ConnectionInterfaces;
                parameters.RecommendationsArguments.ShieldedType = currentRecommendationsArguments.ShieldedType;
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
                IsolationType = IsolationType.Indoor;
                IsolationMaterial = IsolationMaterial.PVC;
                ShieldedType = ShieldedType.UTP;
                ConnectionInterfaces = new List<ConnectionInterfaceStandard>
                {
                    ConnectionInterfaceStandard.None
                };
            }
        }
    }
}
