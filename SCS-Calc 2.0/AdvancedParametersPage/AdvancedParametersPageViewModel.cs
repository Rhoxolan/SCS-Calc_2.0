using CommunityToolkit.Mvvm.ComponentModel;

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
        }

        public double TechnologicalReserve
        {
            get => model.TechnologicalReserve;
            set => model.TechnologicalReserve = value;
        }

        public decimal TechnologicalReserveDiapasonMin => model.Diapasons.TechnologicalReserveDiapason.Min;

        public decimal TechnologicalReserveDiapasonMax => model.Diapasons.TechnologicalReserveDiapason.Max;

        //Обработчик для изменения значения коэффициента технологического запаса
        private void TechnologicalReserveChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(TechnologicalReserve));
        }

        //Обработчик для изменения значения даипазонов вводимых параметров расчёта конфигураций
        private void DiapasonsChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(TechnologicalReserveDiapasonMin));
            OnPropertyChanged(nameof(TechnologicalReserveDiapasonMax));
        }
    }
}
