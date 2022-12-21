using SCSCalc.Parameters;

namespace SCSCalc
{
    /// <summary>
    /// Класс, представляющий параметры расчёта конфигураций СКС
    /// </summary>
    public class ConfigurationCalculateParameters
    {
        private ConfigurationCalculateContext configurationCalculateContext;

        public ConfigurationCalculateParameters()
        {
            configurationCalculateContext = new();
        }

        /// <summary>
        /// Расчёт конфигурации СКС
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public Configuration Calculate(SCSCalcParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces, int numberOfPorts, double? cableHankMeterage)
            => configurationCalculateContext.Calculate(parameters, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts, cableHankMeterage);

        /// <summary>
        /// Установка значения учета метража кабеля в 1-й кабельной катушке при расчёте конфигурации СКС
        /// </summary>
        public bool? IsCableHankMeterageAvailability
        {
            set => configurationCalculateContext.IsCableHankMeterageAvailability = value;
        }
    }
}
