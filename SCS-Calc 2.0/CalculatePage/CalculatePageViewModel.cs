using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SCSCalc;
using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

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

        public int NumberOfWorkplaces { get; set; }

        public int NumberOfPorts { get; set; }

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

        public decimal MinPermanentLinkDiapasonMin => model.Diapasons.MinPermanentLinkDiapason.Min;

        public decimal MinPermanentLinkDiapasonMax => model.Diapasons.MinPermanentLinkDiapason.Max;

        public decimal MaxPermanentLinkDiapasonMin => model.Diapasons.MaxPermanentLinkDiapason.Min;

        public decimal MaxPermanentLinkDiapasonMax => model.Diapasons.MaxPermanentLinkDiapason.Max;

        public decimal NumberOfWorkplacesDiapasonMin => model.Diapasons.NumberOfWorkplacesDiapason.Min;

        public decimal NumberOfWorkplacesDiapasonMax => model.Diapasons.NumberOfWorkplacesDiapason.Max;

        public decimal NumberOfPortsDiapasonMin => model.Diapasons.NumberOfPortsDiapason.Min;

        public decimal NumberOfPortsDiapasonMax => model.Diapasons.NumberOfPortsDiapason.Max;

        public decimal CableHankMeterageDiapasonMin => model.Diapasons.CableHankMeterageDiapason.Min;

        public decimal CableHankMeterageDiapasonMax => model.Diapasons.CableHankMeterageDiapason.Max;

        [RelayCommand]
        private void СalculateConfiguration() => model.СalculateConfiguration(MinPermanentLink, MaxPermanentLink, NumberOfWorkplaces, NumberOfPorts, CableHankMeterage);

        [RelayCommand]
        private void SetCableHankMeterage(string value)
        {
            CableHankMeterage = Convert.ToDouble(value);
            OnPropertyChanged(nameof(CableHankMeterage));
        }

        //Обработчик для изменения значения даипазонов вводимых параметров расчёта конфигураций СКС
        private void DiapasonsChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(MinPermanentLinkDiapasonMin));
            OnPropertyChanged(nameof(MinPermanentLinkDiapasonMax));
            OnPropertyChanged(nameof(MaxPermanentLinkDiapasonMin));
            OnPropertyChanged(nameof(MaxPermanentLinkDiapasonMax));
            OnPropertyChanged(nameof(NumberOfWorkplacesDiapasonMin));
            OnPropertyChanged(nameof(NumberOfWorkplacesDiapasonMax));
            OnPropertyChanged(nameof(NumberOfPortsDiapasonMin));
            OnPropertyChanged(nameof(NumberOfPortsDiapasonMax));
            OnPropertyChanged(nameof(CableHankMeterageDiapasonMin));
            OnPropertyChanged(nameof(CableHankMeterageDiapasonMax));
        }

        //Обработчик для изменения значения коэффициента технологического запаса
        private void TechnologicalReserveChanged(object? sender = null, object? args = null)
        {
            OnPropertyChanged(nameof(TechnologicalReserve));
            OnPropertyChanged(nameof(AveragePermanentLink));
        }
    }
}
