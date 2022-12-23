using static SCSCalc.Parameters.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Инкапсулирован в класс DiapasonContext.

    /// <summary>
    /// Класс для работы со значением коэффициента технологического запаса без его учёта
    /// </summary>
    internal class NonTechnologicalReserveStrategy : ITechnologicalReserveStrategy
    {
        /// <summary>
        /// Значение коэффициента технологического запаса
        /// </summary>
        public double TechnologicalReserve
        {
            get => Convert.ToDouble(NonTechnologicalReserve_TechnologicalReserve);

            set => throw new SCSCalcException("Учёт технологичегского запаса отключён. Пожалуйста, проверьте настройки.");
        }
    }
}
