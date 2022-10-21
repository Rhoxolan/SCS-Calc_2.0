namespace SCSCalc.Parameters
{
    /// <summary>
    /// Класс, определяющий диапазон ввода определённого параметра расчёта конфигурации СКС
    /// </summary>
    public class SCSCalcInputDiapason
    {
        public SCSCalcInputDiapason(decimal min, decimal max)
        {
            Min = min;
            Max = max;
        }

        public SCSCalcInputDiapason((decimal Min, decimal Max) diapason)
        {
            Min = diapason.Min;
            Max = diapason.Max;
        }

        /// <summary>
        /// Минимальное значение ввода параметра расчёта конфигурации СКС
        /// </summary>
        public decimal Min { get; set; }

        /// <summary>
        /// Максимальное значение ввода параметра расчёта конфигурации СКС
        /// </summary>
        public decimal Max { get; set; }
    }
}
