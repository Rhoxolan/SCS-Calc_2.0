using SCSCalc.Parameters;

namespace SCSCalc.Calculate
{
    /// <summary>
    /// //Класс, инкапсулирующий объекты для работы с параметрами расчёта конфигураций СКС
    /// </summary>
    internal class ConfigurationCalculateContext
    {
        private IConfigurationCalculatorStrategy? configurationCalculatorStrategy;

        public ConfigurationCalculateContext()
        {
            configurationCalculatorStrategy = null;
        }

        /// <summary>
        /// Расчёт конфигурации СКС
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
        /// Установка значения учета метража кабеля в 1-й кабельной катушке при расчёте конфигурации СКС
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