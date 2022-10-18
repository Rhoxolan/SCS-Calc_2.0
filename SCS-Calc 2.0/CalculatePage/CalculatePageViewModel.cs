using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SCSCalc;
using System;
using System.Collections.ObjectModel;

namespace SCS_Calc_2._0
{
    [INotifyPropertyChanged]
    public partial class CalculatePageViewModel
    {
        private readonly ApplicationModel model;

        public CalculatePageViewModel(ApplicationModel model)
        {
            this.model = model;
        }

        public double MinPermanentLink { get; set; } = 1;

        public double MaxPermanentLink { get; set; } = 1;

        public int NumberOfWorkplaces { get; set; } = 1;

        public int NumberOfPorts { get; set; } = 1;

        public double? CableHankMeterage { get; set; } = null;

        [RelayCommand]
        private void СalculateConfiguration() => model.СalculateConfiguration(MinPermanentLink, MaxPermanentLink, NumberOfWorkplaces, NumberOfPorts, CableHankMeterage);

        [RelayCommand]
        private void SetCableHankMeterage(string value)
        {
            CableHankMeterage = Convert.ToDouble(value);
            OnPropertyChanged(nameof(CableHankMeterage));
        }
    }
}
