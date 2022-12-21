namespace SCSCalc.Parameters
{
    //Класс, инкапсулирующий объекты, предназначенные для определения диапазона вводимых значений параметров конфигураций СКС, реализующие
    //интерфейсы IStrictСomplianceWithTheStandart, IAnArbitraryNumberOfPorts и IStandartValues.

    /// <summary>
    /// Класс, инкапсулирующий объекты, предназначенные для определения диапазона вводимых значений параметров конфигураций СКС
    /// </summary>
    internal class DiapasonContext
    {
        private IStrictСomplianceWithTheStandart? complianceWithTheStandart;
        private IAnArbitraryNumberOfPorts? numberOfPorts;
        private IStandartValues? standartValues;

        public DiapasonContext()
        {
            IsStrictСomplianceWithTheStandart = null;
            IsAnArbitraryNumberOfPorts = null;
            complianceWithTheStandart = null;
            numberOfPorts = null;
            standartValues = new StandartValues();
        }

        /// <summary>
        /// Диапазоны вводимых значений параметров расчёта конфигураций СКС
        /// </summary>
        public SCSCalcDiapasons Diapasons
        {
            get
            {
                if (standartValues == null || complianceWithTheStandart == null || numberOfPorts == null)
                {
                    throw new SCSCalcException("Ошибка инициализации параметров значений конфигураций");
                }
                return new SCSCalcDiapasons
                {
                    MinPermanentLinkDiapason = new SCSCalcInputDiapason
                    {
                        Min = complianceWithTheStandart.MinPermanentLinkDiapason.Min,
                        Max = complianceWithTheStandart.MinPermanentLinkDiapason.Max
                    },
                    MaxPermanentLinkDiapason = new SCSCalcInputDiapason
                    {
                        Min = complianceWithTheStandart.MaxPermanentLinkDiapason.Min,
                        Max = complianceWithTheStandart.MaxPermanentLinkDiapason.Max
                    },
                    NumberOfPortsDiapason = new SCSCalcInputDiapason
                    {
                        Min = numberOfPorts.NumberOfPortsDiapason.Min,
                        Max = numberOfPorts.NumberOfPortsDiapason.Max
                    },
                    NumberOfWorkplacesDiapason = new SCSCalcInputDiapason
                    {
                        Min = standartValues.NumberOfWorkplacesDiapason.Min,
                        Max = standartValues.NumberOfWorkplacesDiapason.Max
                    },
                    CableHankMeterageDiapason = new SCSCalcInputDiapason
                    {
                        Min = standartValues.CableHankMeterageDiapason.Min,
                        Max = standartValues.CableHankMeterageDiapason.Max
                    },
                    TechnologicalReserveDiapason = new SCSCalcInputDiapason
                    {
                        Min = standartValues.TechnologicalReserveDiapason.Min,
                        Max = standartValues.TechnologicalReserveDiapason.Max
                    }
                };
            }
        }

        /// <summary>
        /// Разрешен или нет ввод значений в соответствии стандарту ISO/IEC 11801
        /// </summary>
        public bool? IsStrictСomplianceWithTheStandart
        {
            get
            {
                if (complianceWithTheStandart is StrictСomplianceWithTheStandart)
                {
                    return true;
                }
                if (complianceWithTheStandart is NonStrictСomplianceWithTheStandart)
                {
                    return false;
                }
                throw new SCSCalcException("Значение соответствия стандарту ISO/IEC 11801 не инициализировано. Пожалуйста, проверьте настройки.");
            }
            set
            {
                if (Equals(value, true))
                {
                    complianceWithTheStandart = new StrictСomplianceWithTheStandart();
                }
                else
                {
                    complianceWithTheStandart = new NonStrictСomplianceWithTheStandart();
                }
            }
        }

        /// <summary>
        /// Разрешен или нет произвольный ввод значений количества портов на 1 рабочее место
        /// </summary>
        public bool? IsAnArbitraryNumberOfPorts
        {
            get
            {
                if (numberOfPorts is AnArbitraryNumberOfPorts)
                {
                    return true;
                }
                if (numberOfPorts is NotAnArbitraryNumberOfPorts)
                {
                    return false;
                }
                throw new SCSCalcException("Значение соответствия стандарту ISO/IEC 11801 не инициализировано. Пожалуйста, проверьте настройки.");
            }
            set
            {
                if (Equals(value, true))
                {
                    numberOfPorts = new AnArbitraryNumberOfPorts();
                }
                else
                {
                    numberOfPorts = new NotAnArbitraryNumberOfPorts();
                }
            }
        }
    }
}
