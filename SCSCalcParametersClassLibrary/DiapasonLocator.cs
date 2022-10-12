namespace SCSCalc.Parameters
{
    //Класс, инкапсулирующий объекты, предназначенные для определения диапазона вводимых значений параметров конфигураций СКС, реализующие
    //интерфейсы IStrictСomplianceWithTheStandart, IAnArbitraryNumberOfPorts и IStandartValues.

    /// <summary>
    /// Класс, инкапсулирующий объекты, предназначенные для определения диапазона вводимых значений параметров конфигураций СКС
    /// </summary>
    internal class DiapasonLocator
    {
        private IStrictСomplianceWithTheStandart? complianceWithTheStandart;
        private IAnArbitraryNumberOfPorts? numberOfPorts;
        private IStandartValues? standartValues;

        public DiapasonLocator()
        {
            complianceWithTheStandart = null;
            numberOfPorts = null;
            standartValues = null;
        }

        /// <summary>
        /// Определяет диапазон ввода значения минимальной длины постоянного линка
        /// </summary>
        public (decimal Min, decimal Max) MinPermanentLinkDiapason
        {
            get
            {
                if (complianceWithTheStandart != null)
                {
                    return complianceWithTheStandart.MinPermanentLinkDiapason;
                }
                else
                {
                    throw new SCSCalcException("Значение соответствия стандарту ISO/IEC 11801 не инициализировано. Пожалуйста, проверьте настройки.");
                }
            }
        }

        /// <summary>
        /// Определяет диапазон ввода значения максимальной длины постоянного линка
        /// </summary>
        public (decimal Min, decimal Max) MaxPermanentLinkDiapason
        {
            get
            {
                if (complianceWithTheStandart != null)
                {
                    return complianceWithTheStandart.MaxPermanentLinkDiapason;
                }
                else
                {
                    throw new SCSCalcException("Значение соответствия стандарту ISO/IEC 11801 не инициализировано. Пожалуйста, проверьте настройки.");
                }
            }
        }

        /// <summary>
        /// Определяет диапазон ввода значения количества портов на 1 рабочее место
        /// </summary>
        public (decimal Min, decimal Max) NumberOfPortsDiapason
        {
            get
            {
                if (numberOfPorts != null)
                {
                    return numberOfPorts.NumberOfPortsDiapason;
                }
                else
                {
                    throw new SCSCalcException("Значение соответствия стандарту ISO/IEC 11801 не инициализировано. Пожалуйста, проверьте настройки.");
                }

            }
        }

        /// <summary>
        /// Определяет диапазон ввода значения количества рабочих мест
        /// </summary>
        public (decimal Min, decimal Max) NumberOfWorkplacesDiapason
        {
            get
            {
                if (standartValues != null)
                {
                    return standartValues.NumberOfWorkplacesDiapason;
                }
                throw new SCSCalcException("Ошибка инициализации параметров значений конфигураций");
            }
        }

        /// <summary>
        /// Определяет диапазон ввода метража кабеля в бухте
        /// </summary>
        public (decimal Min, decimal Max) CableHankMeterageDiapason
        {
            get
            {
                if (standartValues != null)
                {
                    return standartValues.CableHankMeterageDiapason;
                }
                throw new SCSCalcException("Ошибка инициализации параметров значений конфигураций");
            }
        }

        /// <summary>
        /// Определяет диапазон ввода значения технологического запаса
        /// </summary>
        public (decimal Min, decimal Max) TechnologicalReserveDiapason
        {
            get
            {
                if (standartValues != null)
                {
                    return standartValues.TechnologicalReserveDiapason;
                }
                throw new SCSCalcException("Ошибка инициализации параметров значений конфигураций");
            }
        }
    }
}
