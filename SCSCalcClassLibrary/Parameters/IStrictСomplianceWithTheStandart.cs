namespace SCSCalc.Parameters
{
    //Инкапсулирован в DiapasonContext.

    /// <summary>
    /// Интерфейс для определения диапазона вводимых значений параметров расчёта конфигураций в соответствии стандарту ISO/IEC 11801.
    /// </summary>
    internal interface IStrictСomplianceWithTheStandart
    {
        /// <summary>
        /// Определяет диапазон вводимых значений минимальной длины постоянного линка
        /// </summary>
        public (decimal Min, decimal Max) MinPermanentLinkDiapason { get; }

        /// <summary>
        /// Определяет диапазон вводимых значений максималньой длины постоянного линка
        /// </summary>
        public (decimal Min, decimal Max) MaxPermanentLinkDiapason { get; }
    }
}
