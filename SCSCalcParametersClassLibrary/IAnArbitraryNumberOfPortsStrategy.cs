namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class

    /// <summary>
    /// Interface for determination of allowable ports count input value in ISO/IEC 11801 standard accordance
    /// </summary>
    internal interface IAnArbitraryNumberOfPortsStrategy
    {
        /// <summary>
        /// Determines of allowable ports count input value in ISO/IEC 11801 standard accordance
        /// </summary>
        public (decimal Min, decimal Max) NumberOfPortsDiapason { get; }
    }
}
