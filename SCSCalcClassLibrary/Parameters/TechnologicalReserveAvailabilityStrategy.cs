using static SCSCalc.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Инкапсулирован в класс ValueContext.

    /// <summary>
    /// Класс для работы со значением коэффициента технологического запаса с его учётом
    /// </summary>
    internal class TechnologicalReserveAvailabilityStrategy : ITechnologicalReserveStrategy
    {
        private double? technologicalReserve;

        public TechnologicalReserveAvailabilityStrategy()
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
                    technologicalReserve = Convert.ToDouble(TechnologicalReserveAvailability_TechnologicalReserve_Default);
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