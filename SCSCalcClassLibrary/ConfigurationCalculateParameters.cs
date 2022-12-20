using SCSCalc.Parameters;

namespace SCSCalc
{
    /// <summary>
    /// Класс, представляющий параметры расчёта конфигураций СКС
    /// </summary>
    public class ConfigurationCalculateParameters
    {
        private IConfigurationCalculator? configurationCalculator;

        public ConfigurationCalculateParameters()
        {
            configurationCalculator = null;
        }

        /// <summary>
        /// Расчёт конфигурации СКС
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        internal Configuration Calculate(SCSCalcParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces, int numberOfPorts, double? cableHankMeterage)
        {
            if(configurationCalculator != null)
            {
                return configurationCalculator.Calculate(parameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts, cableHankMeterage);
            }
            throw new SCSCalcException("Значение учёта метража кабеля в 1-й кабельной катушке не инициализировано. Пожалуйста, проверьте параметры расчёта.");
        }

        /// <summary>
        /// Установка значения учета метража кабеля в 1-й кабельной катушке при расчёте конфигурации СКС
        /// </summary>
        public bool? IsCableHankMeterageAvailability
        {
            set
            {
                if (value is null)
                {
                    configurationCalculator = null;
                    return;
                }
                if (Equals(value, true))
                {
                    configurationCalculator = new ConfigurationCalculatorWithHankMeterage();
                    return;
                }
                if (Equals(value, false))
                {
                    configurationCalculator = new ConfigurationCalculatorWithoutHankMeterage();
                }
            }
        }
    }
}