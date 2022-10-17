using SCSCalc;
using System.Collections.ObjectModel;

namespace SCS_Calc_2._0
{
    public class ApplicationModel
    {
        private ObservableCollection<Configuration> configurations;

        public ApplicationModel()
        {
            configurations = new();
            Configurations = new(configurations);
        }

        public ReadOnlyObservableCollection<Configuration> Configurations { get; }
    }
}
