namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class

    /// <summary>
    /// Interface for determine of structured cabling configurations standart input parameters
    /// </summary>
    internal interface IStandartValuesStrategy
    {
        /// <summary>
        /// Determines input diapason of workplaces count
        /// </summary>
        public (decimal Min, decimal Max) NumberOfWorkplacesDiapason { get; }

        /// <summary>
        /// Determines input diapason of cable hank meterage
        /// </summary>
        public (decimal Min, decimal Max) CableHankMeterageDiapason { get; }

        /// <summary>
        /// Determines input diapason of technological reserve value
        /// </summary>
        public (decimal Min, decimal Max) TechnologicalReserveDiapason { get; }
    }
}
