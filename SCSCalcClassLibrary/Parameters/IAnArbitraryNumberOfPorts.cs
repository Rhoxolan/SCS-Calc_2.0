namespace SCSCalc.Parameters
{
    //Инкапсулирован в DiapasonLocator.

    /// <summary>
    /// Интерфейс для определения диапазона допустимого вводимого значения количества портов на 1 рабочее место в соответствии стандарту ISO/IEC 11801.
    /// </summary>
    internal interface IAnArbitraryNumberOfPorts
    {
        /// <summary>
        /// Определяет диапазон допустимого вводимого значения количества портов на 1 рабочее место в соответствии стандарту ISO/IEC 11801. 
        /// </summary>
        public (decimal Min, decimal Max) NumberOfPortsDiapason { get; }
    }
}
