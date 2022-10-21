using CommunityToolkit.Mvvm.ComponentModel;
using SCSCalc.Parameters;

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
            model.RecommendationsArgumentsChanged += RecommendationsArgumentsChanged;
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

        public SCSCalcDiapasons Diapasons
        {
            get => model.Diapasons;
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

        //Обработчик для изменения значения коэффициента технологического запаса
        private void TechnologicalReserveChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(TechnologicalReserve));
        }

        //Обработчик для изменения значения даипазонов вводимых параметров расчёта конфигураций СКС
        private void DiapasonsChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(Diapasons));
            OnPropertyChanged(nameof(Diapasons));
        }

        //Обработчик для изменения параметров расчёта конфигураций СКС
        private void ParametersChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(IsTechnologicalReserveAvailability));
        }

        //Обработчик для изменения аргументов получения рекомендаций по побдору кабеля
        private void RecommendationsArgumentsChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(IsolationType));
            OnPropertyChanged(nameof(IsolationMaterial));
            OnPropertyChanged(nameof(ShieldedType));
            OnPropertyChanged(nameof(ConnectionInterfaceStandard));
        }
    }
}
