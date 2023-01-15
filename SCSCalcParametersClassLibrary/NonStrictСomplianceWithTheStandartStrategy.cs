using static SCSCalc.Parameters.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext

    /// <summary>
    /// Class for determine of calculate structured cabling configuration input parameters diapasons if compliance with ISO/IEC 11801 standard is not strict
    /// </summary>
    internal class NonStrictСomplianceWithTheStandartStrategy : IStrictСomplianceWithTheStandartStrategy
    {
        /// <summary>
        /// Determines the diapason of minimal permanent link length input values if compliance with ISO/IEC 11801 standard is not strict
        /// </summary>
        public (decimal Min, decimal Max) MinPermanentLinkDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(NonStrictСomplianceWithTheStandart_MinPermanentLinkDiapason_Min);
                decimal max = Convert.ToDecimal(NonStrictСomplianceWithTheStandart_MinPermanentLinkDiapason_Max);
                return (min, max);
            }
        }

        /// <summary>
        /// Determines the diapason of maximal permanent link length input values if compliance with ISO/IEC 11801 standard is not strict
        /// </summary>
        public (decimal Min, decimal Max) MaxPermanentLinkDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(NonStrictСomplianceWithTheStandart_MaxPermanentLinkDiapason_Min);
                decimal max = Convert.ToDecimal(NonStrictСomplianceWithTheStandart_MaxPermanentLinkDiapason_Max);
                return (min, max);
            }
        }
    }
}
