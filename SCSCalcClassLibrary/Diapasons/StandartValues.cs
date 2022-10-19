namespace SCSCalc
{
    //Класс для определения диапазона стандартных вводимых параметров конфигураций СКС.
    //Инкапсулирован в класс SettingsLocator.

    /// <summary>
    /// Класс для определения диапазона стандартных вводимых параметров конфигураций СКС.
    /// </summary>
    internal class StandartValues : IStandartValues
    {
        /// <summary>
        /// Определяет диапазон ввода количества рабочих мест
        /// </summary>
        public (decimal Min, decimal Max) NumberOfWorkplacesDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(Properties.Resources.StandartValues_NumberOfWorkplacesDiapason_Min);
                decimal max = Convert.ToDecimal(Properties.Resources.StandartValues_NumberOfWorkplacesDiapason_Max);
                return (min, max);
            }
        }

        /// <summary>
        /// Определяет диапазон ввода метража кабеля в бухте
        /// </summary>
        public (decimal Min, decimal Max) CableHankMeterageDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(Properties.Resources.StandartValues_CableHankMeterageDiapason_Min);
                decimal max = Convert.ToDecimal(Properties.Resources.StandartValues_CableHankMeterageDiapason_Max);
                return (min, max);
            }
        }

        /// <summary>
        /// Определяет диапазон ввода значения технологического запаса
        /// </summary>
        public (decimal Min, decimal Max) TechnologicalReserveDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(Properties.Resources.StandartValues_TechnologicalReserveDiapason_Min);
                decimal max = Convert.ToDecimal(Properties.Resources.StandartValues_TechnologicalReserveDiapason_Max);
                return (min, max);
            }
        }
    }
}
