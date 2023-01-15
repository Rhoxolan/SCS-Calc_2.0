using static SCSCalc.Parameters.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class.

    /// <summary>
    /// Class for determine of structured cabling configuration calculating input parameters in strict accordance to ISO/IEC 11801 standard
    /// </summary>
    internal class StrictСomplianceWithTheStandartStrategy : IStrictСomplianceWithTheStandartStrategy
    {
        /// <summary>
        /// Determines the diapason of minimal permanent link length input values in strict accordance to ISO/IEC 11801 standard
        /// </summary>
        public (decimal Min, decimal Max) MinPermanentLinkDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(StrictСomplianceWithTheStandart_MinPermanentLinkDiapason_Min);
                decimal max = Convert.ToDecimal(StrictСomplianceWithTheStandart_MinPermanentLinkDiapason_Max);
                return (min, max);
            }
        }

        /// <summary>
        /// Determines the diapason of maximal permanent link length input values in strict accordance to ISO/IEC 11801 standard
        /// </summary>
        public (decimal Min, decimal Max) MaxPermanentLinkDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(StrictСomplianceWithTheStandart_MaxPermanentLinkDiapason_Min);
                decimal max = Convert.ToDecimal(StrictСomplianceWithTheStandart_MaxPermanentLinkDiapason_Max);
                return (min, max);
            }
        }
    }
}
