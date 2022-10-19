﻿using CommunityToolkit.Mvvm.ComponentModel;
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
        private double? cableHankMeterage;

        public CalculatePageViewModel(ApplicationModel model)
        {
            this.model = model;
            model.DiapasonsChanged += DiapasonsChanged;
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

        //Обработчик для изменения значения даипазонов вводимых параметров расчёта конфигураций
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
