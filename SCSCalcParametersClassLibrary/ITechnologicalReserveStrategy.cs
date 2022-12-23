namespace SCSCalc.Parameters
{
    //Инкапсулирован в класс ValueContext.

    /// <summary>
    /// Интерфейс для работы со значением коэффициента технологического запаса.
    /// </summary>
    internal interface ITechnologicalReserveStrategy
    {
        /// <summary>
        /// Значение коэффициента технологического запаса
        /// </summary>
        public double TechnologicalReserve { get; set; }
    }
}
