namespace SCSCalc.Parameters
{
    //Класс для определения диапазона вводимых значений параметров расчёта конфигураций без
    //строгого соответствия стандарту ISO/IEC 11801. Инкапсулирован в DiapasonLocator.

    /// <summary>
    /// Класс для определения диапазона вводимых значений параметров расчёта конфигураций без строгого соответствия стандарту ISO/IEC 11801.
    /// </summary>
    internal class NonStrictСomplianceWithTheStandart : IStrictСomplianceWithTheStandart
    {
        /// <summary>
        /// Определяет диапазон вводимых значений минимальной длины постоянного линка без строгого соответствия стандарту ISO/IEC 11801.
        /// </summary>
        public (decimal Min, decimal Max) MinPermanentLinkDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(Properties.Resources.NonStrictСomplianceWithTheStandart_MinPermanentLinkDiapason_Min);
                decimal max = Convert.ToDecimal(Properties.Resources.NonStrictСomplianceWithTheStandart_MinPermanentLinkDiapason_Min);
                return (min, max);
            }
        }

        /// <summary>
        /// Определяет диапазон вводимых значений максимальной длины постоянного линка без строгого соответствия стандарту ISO/IEC 11801.
        /// </summary>
        public (decimal Min, decimal Max) MaxPermanentLinkDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(Properties.Resources.NonStrictСomplianceWithTheStandart_MaxPermanentLinkDiapason_Min);
                decimal max = Convert.ToDecimal(Properties.Resources.NonStrictСomplianceWithTheStandart_MaxPermanentLinkDiapason_Min);
                return (min, max);
            }
        }
    }
}
