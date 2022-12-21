using static SCSCalc.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Инкапсулирован в DiapasonContext.

    /// <summary>
    /// Класс для определения диапазона допустимого вводимого значения количества портов на 1 рабочее место при допустимом произвольном количестве.
    /// </summary>
    internal class AnArbitraryNumberOfPorts : IAnArbitraryNumberOfPorts
    {
        /// <summary>
        /// Определяет диапазон допустимого вводимого значения количества портов на 1 рабочее место при допустимом произвольном количестве.
        /// </summary>
        public (decimal Min, decimal Max) NumberOfPortsDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(AnArbitraryNumberOfPorts_NumberOfPortsDiapason_Min);
                decimal max = Convert.ToDecimal(AnArbitraryNumberOfPorts_NumberOfPortsDiapason_Max);
                return (min, max);
            }
        }
    }
}
