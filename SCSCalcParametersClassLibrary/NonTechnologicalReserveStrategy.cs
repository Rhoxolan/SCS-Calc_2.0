using static SCSCalc.Parameters.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class.

    /// <summary>
    /// Class for work with technological reserve coefficient value if it availability is disabled
    /// </summary>
    internal class NonTechnologicalReserveStrategy : ITechnologicalReserveStrategy
    {
        /// <summary>
        /// Technological reserve coefficient value
        /// </summary>
        public double TechnologicalReserve
        {
            get => Convert.ToDouble(NonTechnologicalReserve_TechnologicalReserve);

            set => throw new SCSCalcException("Учёт технологичегского запаса отключён. Пожалуйста, проверьте настройки.");
        }
    }
}
