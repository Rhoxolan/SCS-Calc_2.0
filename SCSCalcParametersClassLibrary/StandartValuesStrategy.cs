using static SCSCalc.Parameters.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class

    /// <summary>
    /// Class for determine of structured cabling configuration input standard parameters diapasons
    /// </summary>
    internal class StandartValuesStrategy : IStandartValuesStrategy
    {
        /// <summary>
        /// Determines of workplaces count input diapason
        /// </summary>
        public (decimal Min, decimal Max) NumberOfWorkplacesDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(StandartValues_NumberOfWorkplacesDiapason_Min);
                decimal max = Convert.ToDecimal(StandartValues_NumberOfWorkplacesDiapason_Max);
                return (min, max);
            }
        }

        /// <summary>
        /// Determines diapason of cable hank meterage input
        /// </summary>
        public (decimal Min, decimal Max) CableHankMeterageDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(StandartValues_CableHankMeterageDiapason_Min);
                decimal max = Convert.ToDecimal(StandartValues_CableHankMeterageDiapason_Max);
                return (min, max);
            }
        }

        /// <summary>
        /// Determines diapason of technological reserve value input
        /// </summary>
        public (decimal Min, decimal Max) TechnologicalReserveDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(StandartValues_TechnologicalReserveDiapason_Min);
                decimal max = Convert.ToDecimal(StandartValues_TechnologicalReserveDiapason_Max);
                return (min, max);
            }
        }
    }
}
