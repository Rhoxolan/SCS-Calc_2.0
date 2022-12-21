using static SCSCalc.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Инкапсулирован в DiapasonLocator.

    /// <summary>
    /// //Класс для определения диапазона ввода значения количества портов на 1 рабочее место с учетом требований стандарта ISO/IEC 11801.
    /// </summary>
    internal class NotAnArbitraryNumberOfPorts : IAnArbitraryNumberOfPorts
    {
        /// <summary>
        /// Определяет диапазон ввода значения количества портов на 1 рабочее место с учетом требований стандарта ISO/IEC 11801.
        /// </summary>
        public (decimal Min, decimal Max) NumberOfPortsDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(NotAnArbitraryNumberOfPorts_NumberOfPortsDiapason_Min);
                decimal max = Convert.ToDecimal(NotAnArbitraryNumberOfPorts_NumberOfPortsDiapason_Max);
                return (min, max);
            }
        }
    }
}
