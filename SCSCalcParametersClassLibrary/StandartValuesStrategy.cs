using static SCSCalc.Parameters.Properties.Resources;
using static System.Convert;

namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class

    /// <summary>
    /// Class for determine of structured cabling configuration input standard parameters diapasons
    /// </summary>
    internal class StandartValuesStrategy : IStandartValuesStrategy
    {
        private (decimal Min, decimal Max) numberOfWorkplacesDiapason;
        private (decimal Min, decimal Max) cableHankMeterageDiapason;
        private (decimal Min, decimal Max) technologicalReserveDiapason;

        public StandartValuesStrategy()
        {
            numberOfWorkplacesDiapason = (ToDecimal(StandartValues_NumberOfWorkplacesDiapason_Min),
                ToDecimal(StandartValues_NumberOfWorkplacesDiapason_Max));
            cableHankMeterageDiapason = (ToDecimal(StandartValues_CableHankMeterageDiapason_Min),
                ToDecimal(StandartValues_CableHankMeterageDiapason_Max));
            technologicalReserveDiapason = (ToDecimal(StandartValues_TechnologicalReserveDiapason_Min),
                ToDecimal(StandartValues_TechnologicalReserveDiapason_Max));
        }

        /// <summary>
        /// Determines of workplaces count input diapason
        /// </summary>
        public (decimal Min, decimal Max) NumberOfWorkplacesDiapason
        {
            get => numberOfWorkplacesDiapason;
        }

        /// <summary>
        /// Determines diapason of cable hank meterage input
        /// </summary>
        public (decimal Min, decimal Max) CableHankMeterageDiapason
        {
            get => cableHankMeterageDiapason;
        }

        /// <summary>
        /// Determines diapason of technological reserve value input
        /// </summary>
        public (decimal Min, decimal Max) TechnologicalReserveDiapason
        {
            get => technologicalReserveDiapason;
        }
    }
}
