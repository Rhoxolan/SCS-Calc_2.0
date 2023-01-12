namespace SCSCalc.Parameters
{
    //Encapsulates in ValueContext class.

    /// <summary>
    /// Intarface for working with technological reserve coefficient value
    /// </summary>
    internal interface ITechnologicalReserveStrategy
    {
        /// <summary>
        /// Value of technological reserve coefficient
        /// </summary>
        public double TechnologicalReserve { get; set; }
    }
}
