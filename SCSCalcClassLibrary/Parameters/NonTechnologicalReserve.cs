namespace SCSCalc.Parameters
{
    //Инкапсулирован в класс SettingsLocator.

    /// <summary>
    /// Класс для работы со значением коэффициента технологического запаса без его учёта
    /// </summary>
    internal class NonTechnologicalReserve : ITechnologicalReserve
    {
        /// <summary>
        /// Значение коэффициента технологического запаса
        /// </summary>
        public double TechnologicalReserve
        {
            get
            {
                return Convert.ToDouble(Properties.Resources.NonTechnologicalReserve_TechnologicalReserve);
            }
            set
            {
                throw new SCSCalcException("Учёт технологичегского запаса отключён. Пожалуйста, проверьте настройки.");
            }
        }
    }
}
