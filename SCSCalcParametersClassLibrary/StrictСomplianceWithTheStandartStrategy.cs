using static SCSCalc.Parameters.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Инкапсулирован в DiapasonContext.

    /// <summary>
    /// Класс для определения диапазона вводимых значений параметров расчёта конфигураций в строгом соответствии стандарту ISO/IEC 11801.
    /// </summary>
    internal class StrictСomplianceWithTheStandartStrategy : IStrictСomplianceWithTheStandartStrategy
    {
        /// <summary>
        /// Определяет диапазон вводимых значений минимальной длины постоянного линка в строгом соответствии стандарту ISO/IEC 11801.
        /// </summary>
        public (decimal Min, decimal Max) MinPermanentLinkDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(StrictСomplianceWithTheStandart_MinPermanentLinkDiapason_Min);
                decimal max = Convert.ToDecimal(StrictСomplianceWithTheStandart_MinPermanentLinkDiapason_Max);
                return (min, max);
            }
        }

        /// <summary>
        /// Определяет диапазон вводимых значений максимальной длины постоянного линка в строгом соответствии стандарту ISO/IEC 11801.
        /// </summary>
        public (decimal Min, decimal Max) MaxPermanentLinkDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(StrictСomplianceWithTheStandart_MaxPermanentLinkDiapason_Min);
                decimal max = Convert.ToDecimal(StrictСomplianceWithTheStandart_MaxPermanentLinkDiapason_Max);
                return (min, max);
            }
        }
    }
}
