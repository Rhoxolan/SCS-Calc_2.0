namespace SCSCalc.Parameters
{
    //Класс, инкапсулирующий объекты, предназначенные для определения диапазона вводимых значений параметров конфигураций СКС, реализующие
    //интерфейсы IStrictСomplianceWithTheStandartStrategy, IAnArbitraryNumberOfPortsStrategy и IStandartValuesStrategy.

    /// <summary>
    /// Класс, инкапсулирующий объекты, предназначенные для определения диапазона вводимых значений параметров конфигураций СКС
    /// </summary>
    internal class DiapasonContext
    {
        private IStrictСomplianceWithTheStandartStrategy? complianceWithTheStandartStrategy;
        private IAnArbitraryNumberOfPortsStrategy? numberOfPortsStrategy;
        private IStandartValuesStrategy? standartValuesStrategy;

        public DiapasonContext()
        {
            IsStrictСomplianceWithTheStandart = null;
            IsAnArbitraryNumberOfPorts = null;
            complianceWithTheStandartStrategy = null;
            numberOfPortsStrategy = null;
            standartValuesStrategy = new StandartValuesStrategy();
        }

        /// <summary>
        /// Диапазоны вводимых значений параметров расчёта конфигураций СКС
        /// </summary>
        public SCSCalcDiapasons Diapasons
        {
            get
            {
                if (standartValuesStrategy == null || complianceWithTheStandartStrategy == null || numberOfPortsStrategy == null)
                {
                    throw new SCSCalcException("Ошибка инициализации параметров значений конфигураций");
                }
                return new SCSCalcDiapasons
                {
                    MinPermanentLinkDiapason = new SCSCalcInputDiapason
                    {
                        Min = complianceWithTheStandartStrategy.MinPermanentLinkDiapason.Min,
                        Max = complianceWithTheStandartStrategy.MinPermanentLinkDiapason.Max
                    },
                    MaxPermanentLinkDiapason = new SCSCalcInputDiapason
                    {
                        Min = complianceWithTheStandartStrategy.MaxPermanentLinkDiapason.Min,
                        Max = complianceWithTheStandartStrategy.MaxPermanentLinkDiapason.Max
                    },
                    NumberOfPortsDiapason = new SCSCalcInputDiapason
                    {
                        Min = numberOfPortsStrategy.NumberOfPortsDiapason.Min,
                        Max = numberOfPortsStrategy.NumberOfPortsDiapason.Max
                    },
                    NumberOfWorkplacesDiapason = new SCSCalcInputDiapason
                    {
                        Min = standartValuesStrategy.NumberOfWorkplacesDiapason.Min,
                        Max = standartValuesStrategy.NumberOfWorkplacesDiapason.Max
                    },
                    CableHankMeterageDiapason = new SCSCalcInputDiapason
                    {
                        Min = standartValuesStrategy.CableHankMeterageDiapason.Min,
                        Max = standartValuesStrategy.CableHankMeterageDiapason.Max
                    },
                    TechnologicalReserveDiapason = new SCSCalcInputDiapason
                    {
                        Min = standartValuesStrategy.TechnologicalReserveDiapason.Min,
                        Max = standartValuesStrategy.TechnologicalReserveDiapason.Max
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
                if (complianceWithTheStandartStrategy is StrictСomplianceWithTheStandartStrategy)
                {
                    return true;
                }
                if (complianceWithTheStandartStrategy is NonStrictСomplianceWithTheStandartStrategy)
                {
                    return false;
                }
                throw new SCSCalcException("Значение соответствия стандарту ISO/IEC 11801 не инициализировано. Пожалуйста, проверьте настройки.");
            }
            set
            {
                if (Equals(value, true))
                {
                    complianceWithTheStandartStrategy = new StrictСomplianceWithTheStandartStrategy();
                }
                else
                {
                    complianceWithTheStandartStrategy = new NonStrictСomplianceWithTheStandartStrategy();
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
                if (numberOfPortsStrategy is AnArbitraryNumberOfPortsStrategy)
                {
                    return true;
                }
                if (numberOfPortsStrategy is NotAnArbitraryNumberOfPortsStrategy)
                {
                    return false;
                }
                throw new SCSCalcException("Значение соответствия стандарту ISO/IEC 11801 не инициализировано. Пожалуйста, проверьте настройки.");
            }
            set
            {
                if (Equals(value, true))
                {
                    numberOfPortsStrategy = new AnArbitraryNumberOfPortsStrategy();
                }
                else
                {
                    numberOfPortsStrategy = new NotAnArbitraryNumberOfPortsStrategy();
                }
            }
        }
    }
}
