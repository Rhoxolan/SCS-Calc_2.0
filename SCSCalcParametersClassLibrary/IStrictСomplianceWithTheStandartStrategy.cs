namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class

    /// <summary>
    /// Intarface for determine of calculate structured cabling configuration input parameters diapasons in accordance with the ISO/IEC 11801 standard.
    /// </summary>
    internal interface IStrictСomplianceWithTheStandartStrategy
    {
        /// <summary>
        /// Determines diapason of minimal permanent link input value
        /// </summary>
        public (decimal Min, decimal Max) MinPermanentLinkDiapason { get; }

        /// <summary>
        /// Determines diapason of maximal permanent link input value
        /// </summary>
        public (decimal Min, decimal Max) MaxPermanentLinkDiapason { get; }
    }
}
