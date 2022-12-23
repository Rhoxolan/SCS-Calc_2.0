using static SCSCalc.Parameters.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Инкапсулирован в DiapasonContext.

    /// <summary>
    /// Класс для определения диапазона вводимых значений параметров расчёта конфигураций без строгого соответствия стандарту ISO/IEC 11801.
    /// </summary>
    internal class NonStrictСomplianceWithTheStandartStrategy : IStrictСomplianceWithTheStandartStrategy
    {
        /// <summary>
        /// Определяет диапазон вводимых значений минимальной длины постоянного линка без строгого соответствия стандарту ISO/IEC 11801.
        /// </summary>
        public (decimal Min, decimal Max) MinPermanentLinkDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(NonStrictСomplianceWithTheStandart_MinPermanentLinkDiapason_Min);
                decimal max = Convert.ToDecimal(NonStrictСomplianceWithTheStandart_MinPermanentLinkDiapason_Max);
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
                decimal min = Convert.ToDecimal(NonStrictСomplianceWithTheStandart_MaxPermanentLinkDiapason_Min);
                decimal max = Convert.ToDecimal(NonStrictСomplianceWithTheStandart_MaxPermanentLinkDiapason_Max);
                return (min, max);
            }
        }
    }
}
