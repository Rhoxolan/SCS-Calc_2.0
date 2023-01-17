namespace SCSCalc.Parameters
{
    //Encapsulates objects which is intended for determine of structured cabling configuration parameters input diapason; these objects are implements
    //IStrictСomplianceWithTheStandartStrategy, IAnArbitraryNumberOfPortsStrategy and IStandartValuesStrategy interfaces

    /// <summary>
    /// Encapsulates objects which is intended for determine of structured cabling configuration parameters input diapason
    /// </summary>
    internal class DiapasonContext
    {
        private IStrictСomplianceWithTheStandartStrategy? complianceWithTheStandartStrategy;
        private StrictСomplianceWithTheStandartStrategy strictСomplianceWithTheStandart;
        private NonStrictСomplianceWithTheStandartStrategy nonStrictСomplianceWithTheStandart;

        private IAnArbitraryNumberOfPortsStrategy? numberOfPortsStrategy;
        private AnArbitraryNumberOfPortsStrategy anArbitraryNumberOfPorts;
        private NotAnArbitraryNumberOfPortsStrategy notAnArbitraryNumberOfPorts;

        private IStandartValuesStrategy? standartValuesStrategy;

        public DiapasonContext()
        {
            complianceWithTheStandartStrategy = null;
            strictСomplianceWithTheStandart = new();
            nonStrictСomplianceWithTheStandart = new();

            numberOfPortsStrategy = null;
            anArbitraryNumberOfPorts = new();
            notAnArbitraryNumberOfPorts = new();

            standartValuesStrategy = new StandartValuesStrategy();
        }

        /// <summary>
        /// Input diapasons of structured cabling configuration calculate parameters
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
        /// Allowed or not to enter values according to ISO/IEC 11801
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
                    complianceWithTheStandartStrategy = strictСomplianceWithTheStandart;
                }
                else
                {
                    complianceWithTheStandartStrategy = nonStrictСomplianceWithTheStandart;
                }
            }
        }

        /// <summary>
        /// Allowed or not to enter arbitrary values of ports count per 1 workplace
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
                    numberOfPortsStrategy = anArbitraryNumberOfPorts;
                }
                else
                {
                    numberOfPortsStrategy = notAnArbitraryNumberOfPorts;
                }
            }
        }
    }
}
