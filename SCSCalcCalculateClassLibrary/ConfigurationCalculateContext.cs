using SCSCalc.Parameters;

namespace SCSCalc.Calculate
{
    /// <summary>
    /// Class, which encapsulates objects to work with parameters of structured cabling configuration calculating
    /// </summary>
    internal class ConfigurationCalculateContext
    {
        private IConfigurationCalculatorStrategy? configurationCalculatorStrategy;

        public ConfigurationCalculateContext()
        {
            configurationCalculatorStrategy = null;
        }

        /// <summary>
        /// Calculating of structured cabling configuration
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public Configuration Calculate(SCSCalcParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces, int numberOfPorts, double? cableHankMeterage)
        {
            if (configurationCalculatorStrategy != null)
            {
                return configurationCalculatorStrategy.Calculate(parameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts, cableHankMeterage);
            }
            throw new SCSCalcException("Значение учёта метража кабеля в 1-й кабельной катушке не инициализировано. Пожалуйста, проверьте параметры расчёта.");
        }

        /// <summary>
        /// The set of the value of 1 hank cable meterage consider when structured cabling configuration calculates
        /// </summary>
        public bool? IsCableHankMeterageAvailability
        {
            set
            {
                if (value is null)
                {
                    configurationCalculatorStrategy = null;
                    return;
                }
                if (Equals(value, true))
                {
                    configurationCalculatorStrategy = new ConfigurationCalculatorWithHankMeterage();
                    return;
                }
                if (Equals(value, false))
                {
                    configurationCalculatorStrategy = new ConfigurationCalculatorWithoutHankMeterage();
                }
            }
        }
    }
}