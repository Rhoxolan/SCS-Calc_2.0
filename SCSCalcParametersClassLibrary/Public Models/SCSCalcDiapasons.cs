namespace SCSCalc.Parameters
{
    /// <summary>
    /// Presents input diapasons of structured cabling configuration calculate parameters
    /// </summary>
    public class SCSCalcDiapasons
    {
        /// <summary>
        /// Input diapason of permanent link minimum value
        /// </summary>
        public required SCSCalcInputDiapason MinPermanentLinkDiapason { get; init; }

        /// <summary>
        /// Input diapason of permanent link maximum value
        /// </summary>
        public required SCSCalcInputDiapason MaxPermanentLinkDiapason { get; init; }

        /// <summary>
        /// Input diapason of ports count per 1 workplace
        /// </summary>
        public required SCSCalcInputDiapason NumberOfPortsDiapason { get; init; }

        /// <summary>
        /// Input diapason of workplaces count
        /// </summary>
        public required SCSCalcInputDiapason NumberOfWorkplacesDiapason { get; init; }

        /// <summary>
        /// Input diapason of cable hank meterage
        /// </summary>
        public required SCSCalcInputDiapason CableHankMeterageDiapason { get; init; }

        /// <summary>
        /// Input diapason of technological reserve value
        /// </summary>
        public required SCSCalcInputDiapason TechnologicalReserveDiapason { get; init; }
    }
}
