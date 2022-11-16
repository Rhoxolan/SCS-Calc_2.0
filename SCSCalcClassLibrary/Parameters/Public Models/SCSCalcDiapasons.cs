namespace SCSCalc.Parameters
{
    /// <summary>
    /// Класс, представляющий диапазоны ввода параметров расчёта конфигурации СКС
    /// </summary>
    public class SCSCalcDiapasons
    {
        /// <summary>
        /// Диапазон ввода значения минимальной длины постоянного линка
        /// </summary>
        public required SCSCalcInputDiapason MinPermanentLinkDiapason { get; init; }

        /// <summary>
        /// Диапазон ввода значения максимальной длины постоянного линка
        /// </summary>
        public required SCSCalcInputDiapason MaxPermanentLinkDiapason { get; init; }

        /// <summary>
        /// Диапазон ввода значения количества портов на 1 рабочее место
        /// </summary>
        public required SCSCalcInputDiapason NumberOfPortsDiapason { get; init; }

        /// <summary>
        /// Диапазон ввода значения количества рабочих мест
        /// </summary>
        public required SCSCalcInputDiapason NumberOfWorkplacesDiapason { get; init; }

        /// <summary>
        /// Диапазон ввода метража кабеля в бухте
        /// </summary>
        public required SCSCalcInputDiapason CableHankMeterageDiapason { get; init; }

        /// <summary>
        /// Диапазон ввода значения технологического запаса
        /// </summary>
        public required SCSCalcInputDiapason TechnologicalReserveDiapason { get; init; }
    }
}
