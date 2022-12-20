using SCSCalc.Parameters;

namespace SCSCalc
{
    /// <summary>
    /// Интерфейс, предоставляющий метод расчёта конфигурации СКС
    /// </summary>
    internal interface IConfigurationCalculator
    {
        /// <summary>
        /// Расчёт конфигурации СКС
        /// </summary>
        Configuration Calculate(SCSCalcParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces,
            int numberOfPorts, double? cableHankMeterage);
    }
}
