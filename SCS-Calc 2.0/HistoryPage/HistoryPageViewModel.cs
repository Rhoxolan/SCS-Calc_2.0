using SCSCalc.WindowsDesktop;
using System.Collections.ObjectModel;

namespace SCS_Calc_2._0
{
    public class HistoryPageViewModel
    {
        private readonly ApplicationModel model;

        public HistoryPageViewModel(ApplicationModel model)
        {
            this.model = model;
        }

        public ReadOnlyObservableCollection<Configuration> Configurations
        {
            get => model.Configurations;
        }

        public Configuration? SelectedConfiguration { get; set; }
    }
}
