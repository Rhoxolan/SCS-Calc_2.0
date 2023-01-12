namespace SCSCalc.Parameters
{
    /// <summary>
    /// Determines the input diapason of structured cabling configuration calculate parameter
    /// </summary>
    public class SCSCalcInputDiapason
    {
        /// <summary>
        /// Minimum input value of structured cabling configuration calculate parameter
        /// </summary>
        public required decimal Min { get; init; }

        /// <summary>
        /// Maximum input value of structured cabling configuration calculate parameter
        /// </summary>
        public required decimal Max { get; init; }
    }
}
