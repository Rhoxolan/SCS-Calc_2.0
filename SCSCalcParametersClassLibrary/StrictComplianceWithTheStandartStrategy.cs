﻿using static SCSCalc.Parameters.Properties.Resources;
using static System.Convert;

namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class.

    /// <summary>
    /// Class for determine of structured cabling configuration calculating input parameters in strict accordance to ISO/IEC 11801 standard
    /// </summary>
    internal class StrictComplianceWithTheStandartStrategy : IStrictComplianceWithTheStandartStrategy
    {
        private (decimal Min, decimal Max) minPermanentLinkDiapason;
        private (decimal Min, decimal Max) maxPermanentLinkDiapason;

        public StrictComplianceWithTheStandartStrategy()
        {
            minPermanentLinkDiapason = (ToDecimal(StrictComplianceWithTheStandart_MinPermanentLinkDiapason_Min),
                ToDecimal(StrictComplianceWithTheStandart_MinPermanentLinkDiapason_Max));
            maxPermanentLinkDiapason = (ToDecimal(StrictComplianceWithTheStandart_MaxPermanentLinkDiapason_Min),
                ToDecimal(StrictComplianceWithTheStandart_MaxPermanentLinkDiapason_Max));
        }

        /// <summary>
        /// Determines the diapason of minimal permanent link length input values in strict accordance to ISO/IEC 11801 standard
        /// </summary>
        public (decimal Min, decimal Max) MinPermanentLinkDiapason
        {
            get => minPermanentLinkDiapason;
        }

        /// <summary>
        /// Determines the diapason of maximal permanent link length input values in strict accordance to ISO/IEC 11801 standard
        /// </summary>
        public (decimal Min, decimal Max) MaxPermanentLinkDiapason
        {
            get => maxPermanentLinkDiapason;
        }
    }
}
