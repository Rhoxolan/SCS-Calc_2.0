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
        private double? cableHankMeterage;

        public CalculatePageViewModel(ApplicationModel model)
        {
            this.model = model;
        }

        public double MinPermanentLink { get; set; } = 1;

        public double MaxPermanentLink { get; set; } = 1;

        public int NumberOfWorkplaces { get; set; } = 1;

        public int NumberOfPorts { get; set; } = 1;

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

        public (
            (decimal Min, decimal Max) MinPermanentLinkDiapason,
            (decimal Min, decimal Max) MaxPermanentLinkDiapason,
            (decimal Min, decimal Max) NumberOfPortsDiapason,
            (decimal Min, decimal Max) NumberOfWorkplacesDiapason,
            (decimal Min, decimal Max) CableHankMeterageDiapason,
            (decimal Min, decimal Max) TechnologicalReserveDiapason
            )
            Diapasons
        {
            get
            {
                return model.Diapasons; //Запустить в отлпдчике и разобраться с ошибкой. Походу нет инициализации IStandartValues
            }
        }

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
