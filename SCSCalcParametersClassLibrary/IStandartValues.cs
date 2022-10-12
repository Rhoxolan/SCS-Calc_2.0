namespace SCSCalc.Parameters
{
    //Интерфейс для определения диапазона стандартных вводимых параметров конфигураций СКС.
    //Инкапсулирован в класс SettingsLocator.

    /// <summary>
    /// Интерфейс для определения диапазона стандартных вводимых параметров конфигураций СКС.
    /// </summary>
    internal interface IStandartValues
    {
        /// <summary>
        /// Определяет диапазон ввода количества рабочих мест
        /// </summary>
        public (decimal Min, decimal Max) NumberOfWorkplacesDiapason { get; }

        /// <summary>
        /// Определяет диапазон ввода метража кабеля в бухте
        /// </summary>
        public (decimal Min, decimal Max) CableHankMeterageDiapason { get; }

        /// <summary>
        /// Определяет диапазон ввода значения технологического запаса
        /// </summary>
        public (decimal Min, decimal Max) TechnologicalReserveDiapason { get; }
    }
}
