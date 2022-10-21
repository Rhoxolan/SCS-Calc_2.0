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

        public IsolationType IsolationType
        {
            get => model.IsolationType;
            set => model.IsolationType = value;
        }

        public IsolationMaterial IsolationMaterial
        {
            get => model.IsolationMaterial;
            set => model.IsolationMaterial = value;
        }

        public ShieldedType ShieldedType
        {
            get => model.ShieldedType;
            set => model.ShieldedType = value;
        }

        public object ConnectionInterfaceStandard
        {
            get => model.ConnectionInterfaceStandard;
            set => model.ConnectionInterfaceStandard = value;
        }

        public decimal TechnologicalReserveDiapasonMin => model.Diapasons.TechnologicalReserveDiapason.Min;

        public decimal TechnologicalReserveDiapasonMax => model.Diapasons.TechnologicalReserveDiapason.Max;

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
