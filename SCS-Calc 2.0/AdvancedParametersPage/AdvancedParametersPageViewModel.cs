using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SCSCalc.Parameters;
using System.Collections.Generic;

namespace SCSCalc_2_0
{
    [INotifyPropertyChanged]
    public partial class AdvancedParametersPageViewModel
    {
        private readonly ApplicationModel model;

        public AdvancedParametersPageViewModel(ApplicationModel model)
        {
            this.model = model;
            model.TechnologicalReserveChanged += TechnologicalReserveChanged;
            model.DiapasonsChanged += DiapasonsChanged;
            model.ParametersChanged += ParametersChanged;
            model.RecommendationsArgumentsChanged += RecommendationsArgumentsChanged;
        }

        public double TechnologicalReserve
        {
            get => model.TechnologicalReserve;
            set => model.TechnologicalReserve = value;
        }

        public IsolationType IsolationType
        {
            get
            {
                return model.IsolationType;
            }
            set
            {
                if (model.IsolationType == IsolationType.Indoor)
                {
                    model.IsolationType = IsolationType.Outdoor;
                }
                else
                {
                    model.IsolationType = IsolationType.Indoor;
                }
            }
        }

        public IsolationMaterial IsolationMaterial
        {
            get
            {
                return model.IsolationMaterial;
            }
            set
            {
                if (model.IsolationMaterial == IsolationMaterial.PVC)
                {
                    model.IsolationMaterial = IsolationMaterial.LSZH;
                }
                else
                {
                    model.IsolationMaterial = IsolationMaterial.PVC;
                }
            }
        }

        public ShieldedType ShieldedType
        {
            get
            {
                return model.ShieldedType;
            }
            set
            {
                if (model.ShieldedType == ShieldedType.UTP)
                {
                    model.ShieldedType = ShieldedType.FTP;
                }
                else
                {
                    model.ShieldedType = ShieldedType.UTP;
                }
            }
        }

        public object ConnectionInterfaceStandard
        {
            get
            {
                return model.ConnectionInterfaces;
            }
            set
            {
                List<ConnectionInterfaceStandard> ConnectionInterfaces = new(model.ConnectionInterfaces);
                if (ConnectionInterfaces.Contains((ConnectionInterfaceStandard)value))
                {
                    ConnectionInterfaces.Remove((ConnectionInterfaceStandard)value);
                    model.ConnectionInterfaces = ConnectionInterfaces;
                }
                else
                {
                    ConnectionInterfaces.Add((ConnectionInterfaceStandard)value);
                    model.ConnectionInterfaces = ConnectionInterfaces;
                }
            }
        }

        public SCSCalcDiapasons Diapasons
        {
            get => model.Diapasons;
        }

        public bool? IsStrictСomplianceWithTheStandart
        {
            get => model.IsStrictСomplianceWithTheStandart;
            set => model.IsStrictСomplianceWithTheStandart = value;
        }

        public bool? IsAnArbitraryNumberOfPorts
        {
            get => model.IsAnArbitraryNumberOfPorts;
            set => model.IsAnArbitraryNumberOfPorts = value;
        }

        public bool? IsTechnologicalReserveAvailability
        {
            get => model.IsTechnologicalReserveAvailability;
            set => model.IsTechnologicalReserveAvailability = value;
        }

        public bool? IsRecommendationsAvailability
        {
            get => model.IsRecommendationsAvailability;
            set => model.IsRecommendationsAvailability = value;
        }

        [RelayCommand]
        private void SetDefaultsParameters() => model.SetDefaultsParameters();


        //Обработчик для изменения значения коэффициента технологического запаса
        private void TechnologicalReserveChanged() => OnPropertyChanged(nameof(TechnologicalReserve));

        //Обработчик для изменения значения даипазонов вводимых параметров расчёта конфигураций СКС
        private void DiapasonsChanged()
        {
            OnPropertyChanged(nameof(Diapasons));
            OnPropertyChanged(nameof(Diapasons));
        }

        //Обработчик для изменения параметров расчёта конфигураций СКС
        private void ParametersChanged()
        {
            OnPropertyChanged(nameof(IsStrictСomplianceWithTheStandart));
            OnPropertyChanged(nameof(IsTechnologicalReserveAvailability));
            OnPropertyChanged(nameof(IsAnArbitraryNumberOfPorts));
        }

        //Обработчик для изменения аргументов получения рекомендаций по побдору кабеля
        private void RecommendationsArgumentsChanged()
        {
            OnPropertyChanged(nameof(IsolationType));
            OnPropertyChanged(nameof(IsolationMaterial));
            OnPropertyChanged(nameof(ShieldedType));
            OnPropertyChanged(nameof(ConnectionInterfaceStandard));
            OnPropertyChanged(nameof(IsRecommendationsAvailability));
        }
    }
}
