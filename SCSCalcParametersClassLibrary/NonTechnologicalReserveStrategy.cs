using static SCSCalc.Parameters.Properties.Resources;
using static System.Convert;

namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class.

    /// <summary>
    /// Class for work with technological reserve coefficient value if it availability is disabled
    /// </summary>
    internal class NonTechnologicalReserveStrategy : ITechnologicalReserveStrategy
    {
        private double technologicalReserve;

        public NonTechnologicalReserveStrategy()
        {
            technologicalReserve = ToDouble(NonTechnologicalReserve_TechnologicalReserve);
        }

        /// <summary>
        /// Technological reserve coefficient value
        /// </summary>
        public double TechnologicalReserve
        {
            get => technologicalReserve;

            set => throw new SCSCalcException("Technological reserve coefficient is not taken into account. Please check the settings.");
        }
    }
}
