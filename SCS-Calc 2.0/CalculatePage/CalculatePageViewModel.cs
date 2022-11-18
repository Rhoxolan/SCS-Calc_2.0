using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SCSCalc.Parameters;
using SCSCalc;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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

        public ReadOnlyObservableCollection<Configuration> Configurations
        {
            get => model.Configurations;
        }

        public Configuration? LatestConfiguration { get; set; } = null;

        //Необходимо для определения нижнего диапазона ввода значения метража кабеля в бухте
        public int CeiledAveragePermanentLink
        {
            get
            {
                return Convert.ToInt32(Math.Ceiling((minPermanentLink + maxPermanentLink) / 2 * TechnologicalReserve));
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
                OnPropertyChanged(nameof(CeiledAveragePermanentLink));
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
                OnPropertyChanged(nameof(CeiledAveragePermanentLink));
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

        public bool? IsCableHankMeterageAvailability
        {
            set => model.IsCableHankMeterageAvailability = value;
        }

        [RelayCommand]
        private async Task СalculateConfigurationAsync()
        {
            await model.СalculateConfigurationAsync(MinPermanentLink, MaxPermanentLink, Convert.ToInt32(NumberOfWorkplaces), Convert.ToInt32(NumberOfPorts), CableHankMeterage);
            LatestConfiguration = Configurations[^1];
            OnPropertyChanged(nameof(LatestConfiguration));
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
            if(LatestConfiguration != null)
            {
                model.SaveToTXT(LatestConfiguration);
            }
        }

        [RelayCommand]
        private void CleanOutputBlock()
        {
            LatestConfiguration = null;
            OnPropertyChanged(nameof(LatestConfiguration));
        }

        //Обработчик для изменения значения даипазонов вводимых параметров расчёта конфигураций СКС
        private void DiapasonsChanged()
        {
            OnPropertyChanged(nameof(Diapasons));
        }

        //Обработчик для изменения значения коэффициента технологического запаса
        private void TechnologicalReserveChanged()
        {
            OnPropertyChanged(nameof(TechnologicalReserve));
            OnPropertyChanged(nameof(CeiledAveragePermanentLink));
        }
    }
}
