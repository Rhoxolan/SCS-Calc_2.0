namespace SCSCalc
{
    /// <summary>
    /// Класс, представляющий диапазоны ввода параметров расчёта конфигурации СКС
    /// </summary>
    public class SCSCalcDiapasons
    {
        /// <summary>
        /// Диапазон ввода значения минимальной длины постоянного линка
        /// </summary>
        public SCSCalcInputDiapason? MinPermanentLinkDiapason { get; init; }

        /// <summary>
        /// Диапазон ввода значения максимальной длины постоянного линка
        /// </summary>
        public SCSCalcInputDiapason? MaxPermanentLinkDiapason { get; init; }

        /// <summary>
        /// Диапазон ввода значения количества портов на 1 рабочее место
        /// </summary>
        public SCSCalcInputDiapason? NumberOfPortsDiapason { get; init; }

        /// <summary>
        /// Диапазон ввода значения количества рабочих мест
        /// </summary>
        public SCSCalcInputDiapason? NumberOfWorkplacesDiapason { get; init; }

        /// <summary>
        /// Диапазон ввода метража кабеля в бухте
        /// </summary>
        public SCSCalcInputDiapason? CableHankMeterageDiapason { get; init; }

        /// <summary>
        /// Диапазон ввода значения технологического запаса
        /// </summary>
        public SCSCalcInputDiapason? TechnologicalReserveDiapason { get; init; }
    }
}
