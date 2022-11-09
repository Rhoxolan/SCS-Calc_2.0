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
        /// <param name="parameters"></param>
        /// <param name="minPermanentLink"></param>
        /// <param name="maxPermanentLink"></param>
        /// <param name="numberOfWorkplaces"></param>
        /// <param name="numberOfPorts"></param>
        /// <param name="cableHankMeterage"></param>
        /// <returns></returns>
        Configuration Calculate(SCSCalcParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces,
            int numberOfPorts, double? cableHankMeterage);
    }
}
