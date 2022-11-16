namespace SCSCalc.Parameters
{
    /// <summary>
    /// Класс, определяющий диапазон ввода определённого параметра расчёта конфигурации СКС
    /// </summary>
    public class SCSCalcInputDiapason
    {
        /// <summary>
        /// Минимальное значение ввода параметра расчёта конфигурации СКС
        /// </summary>
        public required decimal Min { get; init; }

        /// <summary>
        /// Максимальное значение ввода параметра расчёта конфигурации СКС
        /// </summary>
        public required decimal Max { get; init; }
    }
}
