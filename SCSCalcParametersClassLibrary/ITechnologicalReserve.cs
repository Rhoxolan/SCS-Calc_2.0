namespace SCSCalc.Parameters
{
    //Интерфейс для работы со значением коэффициента технологического запаса. Инкапсулирован в класс SettingsLocator.

    /// <summary>
    /// Интерфейс для работы со значением коэффициента технологического запаса.
    /// </summary>
    internal interface ITechnologicalReserve
    {
        /// <summary>
        /// Значение коэффициента технологического запаса
        /// </summary>
        public double TechnologicalReserve { get; set; }
    }
}
