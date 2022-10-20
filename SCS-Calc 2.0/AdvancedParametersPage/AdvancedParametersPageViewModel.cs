using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SCSCalc;

namespace SCS_Calc_2._0
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
        }

        public double TechnologicalReserve
        {
            get => model.TechnologicalReserve;
            set => model.TechnologicalReserve = value;
        }

        public decimal TechnologicalReserveDiapasonMin => model.Diapasons.TechnologicalReserveDiapason.Min;

        public decimal TechnologicalReserveDiapasonMax => model.Diapasons.TechnologicalReserveDiapason.Max;

        public RecommendationsArguments RecommendationsArguments
        {
            get => model.RecommendationsArguments;
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
        private void SetRecommendationArgument(string arg)
        {
            switch (arg)
            {
                case "IsolationType":
                    if (RecommendationsArguments.IsolationType == IsolationType.Outdoor)
                    {
                        RecommendationsArguments.IsolationType = IsolationType.Indoor;
                    }
                    else
                    {
                        RecommendationsArguments.IsolationType = IsolationType.Outdoor;
                    }
                    break;

                case "IsolationMaterial":
                    if (RecommendationsArguments.IsolationMaterial == IsolationMaterial.PVC)
                    {
                        RecommendationsArguments.IsolationMaterial = IsolationMaterial.LSZH;
                    }
                    else
                    {
                        RecommendationsArguments.IsolationMaterial = IsolationMaterial.PVC;
                    }
                    break;

                case "10BASE-T":
                    if (RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.TenBASE_T))
                    {
                        RecommendationsArguments.ConnectionInterfaces.Remove(ConnectionInterfaceStandard.TenBASE_T);
                    }
                    else
                    {
                        RecommendationsArguments.ConnectionInterfaces.Add(ConnectionInterfaceStandard.TenBASE_T);
                    }
                    break;

                case "100BASE-T":
                    if (RecommendationsArguments.ConnectionInterfaces.Contains(ConnectionInterfaceStandard.FastEthernet))
                    {
                        RecommendationsArguments.ConnectionInterfaces.Remove(ConnectionInterfaceStandard.FastEthernet);
                    }
                    else
                    {
                        RecommendationsArguments.ConnectionInterfaces.Add(ConnectionInterfaceStandard.FastEthernet);
                    }
                    break;
            }
        }

        //Обработчик для изменения значения коэффициента технологического запаса
        private void TechnologicalReserveChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(TechnologicalReserve));
        }

        //Обработчик для изменения значения даипазонов вводимых параметров расчёта конфигураций СКС
        private void DiapasonsChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(TechnologicalReserveDiapasonMin));
            OnPropertyChanged(nameof(TechnologicalReserveDiapasonMax));
        }

        //Обработчик для изменения параметров расчёта конфигураций СКС
        private void ParametersChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(IsTechnologicalReserveAvailability));
        }
    }
}
