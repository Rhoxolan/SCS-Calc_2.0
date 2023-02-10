namespace SCSCalc.Parameters
{
    //Encapsulates objects which is intended for determine of structured cabling configuration parameters input diapason; these objects are implements
    //IStrictComplianceWithTheStandartStrategy, IAnArbitraryNumberOfPortsStrategy and IStandartValuesStrategy interfaces

    /// <summary>
    /// Encapsulates objects which is intended for determine of structured cabling configuration parameters input diapason
    /// </summary>
    internal class DiapasonContext
    {
        private IStrictComplianceWithTheStandartStrategy? complianceWithTheStandartStrategy;
        private IAnArbitraryNumberOfPortsStrategy? numberOfPortsStrategy;
        private IStandartValuesStrategy? standartValuesStrategy;

        public DiapasonContext()
        {
            complianceWithTheStandartStrategy = null;
            numberOfPortsStrategy = null;
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
                    throw new SCSCalcException("Structured cabling configuration parameters value initialize error");
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
                if (complianceWithTheStandartStrategy is StrictComplianceWithTheStandartStrategy)
                {
                    return true;
                }
                if (complianceWithTheStandartStrategy is NonStrictComplianceWithTheStandartStrategy)
                {
                    return false;
                }
                throw new SCSCalcException("The value of compliance with the ISO/IEC 11801 standard isn't initialized. Please check the settings.");
            }
            set
            {
                if (Equals(value, true))
                {
                    complianceWithTheStandartStrategy = new StrictComplianceWithTheStandartStrategy();
                }
                else
                {
                    complianceWithTheStandartStrategy = new NonStrictComplianceWithTheStandartStrategy();
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
                throw new SCSCalcException("The value of compliance with the ISO/IEC 11801 standard isn't initialized. Please check the settings.");
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
