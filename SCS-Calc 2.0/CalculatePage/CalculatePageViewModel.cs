using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SCSCalc.Parameters;
using SCSCalc.WindowsDesktop;
using System;

namespace SCS_Calc_2._0
{
    [INotifyPropertyChanged]
    public partial class CalculatePageViewModel
    {
        private readonly ApplicationModel model;
        private double minPermanentLink;
        private double maxPermanentLink;
        private double? cableHankMeterage;

        public CalculatePageViewModel(ApplicationModel model)
        {
            this.model = model;
            model.DiapasonsChanged += DiapasonsChanged;
            model.TechnologicalReserveChanged += TechnologicalReserveChanged;
        }

        //Необходимо для определения нижнего диапазона ввода значения метража кабеля в бухте
        public int AveragePermanentLink
        {
            get
            {
                return (int)((minPermanentLink + maxPermanentLink) / 2 * TechnologicalReserve);
            }
        }

        public double MinPermanentLink
        {
            get
            {
                return minPermanentLink;
            }
            set
            {
                minPermanentLink = value;
                OnPropertyChanged(nameof(AveragePermanentLink));
            }
        }

        public double MaxPermanentLink
        {
            get
            {
                return maxPermanentLink;
            }
            set
            {
                maxPermanentLink = value;
                OnPropertyChanged(nameof(AveragePermanentLink));
            }
        }

        public double NumberOfWorkplaces { get; set; }

        public double NumberOfPorts { get; set; }

        public double? CableHankMeterage
        {
            get
            {
                return cableHankMeterage;
            }
            set
            {
                cableHankMeterage = value;
                OnPropertyChanged(nameof(CableHankMeterage));
            }
        }

        public double TechnologicalReserve
        {
            get => model.TechnologicalReserve;
            set => model.TechnologicalReserve = value;
        }

        public SCSCalcDiapasons Diapasons
        {
            get => model.Diapasons;
        }

        [RelayCommand]
        private void СalculateConfiguration()
        {
            model.СalculateConfiguration(MinPermanentLink, MaxPermanentLink, Convert.ToInt32(NumberOfWorkplaces), Convert.ToInt32(NumberOfPorts), CableHankMeterage);
        }

        [RelayCommand]
        private void SetCableHankMeterage(string value)
        {
            CableHankMeterage = Convert.ToDouble(value);
            OnPropertyChanged(nameof(CableHankMeterage));
        }

        [RelayCommand]
        private void SaveToTXT()
        {

        }

        //Обработчик для изменения значения даипазонов вводимых параметров расчёта конфигураций СКС
        private void DiapasonsChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(Diapasons));
        }

        //Обработчик для изменения значения коэффициента технологического запаса
        private void TechnologicalReserveChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(TechnologicalReserve));
            OnPropertyChanged(nameof(AveragePermanentLink));
        }
    }
}
