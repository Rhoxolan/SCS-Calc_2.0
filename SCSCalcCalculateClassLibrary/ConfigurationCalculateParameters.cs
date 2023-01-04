using SCSCalc.Parameters;

namespace SCSCalc.Calculate
{
    /// <summary>
    /// Presents parameters of structured cabling configuration calculating
    /// </summary>
    public class ConfigurationCalculateParameters
    {
        private ConfigurationCalculateContext configurationCalculateContext;

        public ConfigurationCalculateParameters()
        {
            configurationCalculateContext = new();
        }

        /// <summary>
        /// Calculating of structured cabling configuration
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public Configuration Calculate(SCSCalcParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces, int numberOfPorts, double? cableHankMeterage)
            => configurationCalculateContext.Calculate(parameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts, cableHankMeterage);

        /// <summary>
        /// The set of the value of 1 hank cable meterage consider when structured cabling configuration calculates
        /// </summary>
        public bool? IsCableHankMeterageAvailability
        {
            set => configurationCalculateContext.IsCableHankMeterageAvailability = value;
        }
    }
}
