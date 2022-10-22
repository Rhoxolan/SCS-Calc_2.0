namespace SCSCalc.Parameters
{
    //Инкапсулирован в класс SettingsLocator.

    /// <summary>
    /// Класс для работы со значением коэффициента технологического запаса с его учётом
    /// </summary>
    internal class TechnologicalReserveAvailability : ITechnologicalReserve
    {
        private double? technologicalReserve;

        public TechnologicalReserveAvailability()
        {
            technologicalReserve = null;
        }

        /// <summary>
        /// Значение коэффициента технологического запаса
        /// </summary>
        public double TechnologicalReserve
        {
            get
            {
                if (technologicalReserve != null)
                {
                    return (double)technologicalReserve;
                }
                else
                {
                    technologicalReserve = Convert.ToDouble(Properties.Resources.TechnologicalReserveAvailability_TechnologicalReserve_Default);
                    return (double)technologicalReserve;
                }
            }
            set
            {
                technologicalReserve = value;
            }
        }
    }
}