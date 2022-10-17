namespace SCSCalc
{
    //Класс для определения диапазона допустимого вводимого значения количества портов на 1 рабочее место
    //при допустимом произвольном количестве. Инкапсулирован в DiapasonLocator.

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
                decimal min = Convert.ToDecimal(Properties.Resources.AnArbitraryNumberOfPorts_NumberOfPortsDiapason_Min);
                decimal max = Convert.ToDecimal(Properties.Resources.AnArbitraryNumberOfPorts_NumberOfPortsDiapason_Max);
                return (min, max);
            }
        }
    }
}
