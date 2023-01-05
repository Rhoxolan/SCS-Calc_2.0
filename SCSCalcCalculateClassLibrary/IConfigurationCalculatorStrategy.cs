using SCSCalc.Parameters;

namespace SCSCalc.Calculate
{
    /// <summary>
    /// Presents the calculate method of structured cabling configuration
    /// </summary>
    internal interface IConfigurationCalculatorStrategy
    {
        /// <summary>
        /// Calculate method of structured cabling configuration
        /// </summary>
        Configuration Calculate(SCSCalcParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces,
            int numberOfPorts, double? cableHankMeterage);
    }
}
