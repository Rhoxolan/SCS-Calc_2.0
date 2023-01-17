using static SCSCalc.Parameters.Properties.Resources;

namespace SCSCalc.Parameters
{
    /// <summary>
    /// Class for getting cable selection recommendations if getting recommendations is enabled
    /// </summary>
    internal class RecommendationsAvailabilityStrategy : IRecommendationsStrategy
    {
        /// <summary>
        /// Arguments for getting cable selection recommendations
        /// </summary>
        public RecommendationsArguments RecommendationsArguments { get; } = new();

        /// <summary>
        /// Cable insulation type recommendation
        /// </summary>
        public string RecommendationIsolationType
        {
            get
            {
                if (RecommendationsArguments.IsolationType == IsolationType.Indoor)
                {
                    return RecommendationsAvailability_RecommendationIsolationType_Indoor;
                }
                if (RecommendationsArguments.IsolationType == IsolationType.Outdoor)
                {
                    return RecommendationsAvailability_RecommendationIsolationType_Outdoor;
                }
                if (RecommendationsArguments.IsolationType == IsolationType.None)
                {
                    return RecommendationsAvailability_RecommendationIsolationType_None;
                }
                throw new SCSCalcException("Conformity to cable insulation type isn't determine. Please check the settings.");
            }
        }

        /// <summary>
        /// Cable insulation material recommendation
        /// </summary>
        public string RecommendationIsolationMaterial
        {
            get
            {
                if (RecommendationsArguments.IsolationMaterial == IsolationMaterial.None)
                {
                    return RecommendationsAvailability_RecommendationIsolationMaterial_None;
                }
                if (RecommendationsArguments.IsolationMaterial == IsolationMaterial.LSZH)
                {
                    return RecommendationsAvailability_RecommendationIsolationMaterial_LSZH;
                }
                if (RecommendationsArguments.IsolationMaterial == IsolationMaterial.PVC)
                {
                    return RecommendationsAvailability_RecommendationIsolationMaterial_PVC;
                }
                throw new SCSCalcException("Conformity to cable insulation material isn't determine. Please check the settings.");
            }
        }

        /// <summary>
        /// Cable shielding type recommendation
        /// </summary>
        public string RecommendationShieldedType
        {
            get
            {
                if (RecommendationsArguments.ShieldedType == ShieldedType.None)
                {
                    return RecommendationsAvailability_RecommendationShieldedType_None;
                }
                if (RecommendationsArguments.ShieldedType == ShieldedType.UTP)
                {
                    return RecommendationsAvailability_RecommendationShieldedType_UTP;
                }
                if (RecommendationsArguments.ShieldedType == ShieldedType.FTP)
                {
                    return RecommendationsAvailability_RecommendationShieldedType_FTP;
                }
                throw new SCSCalcException("Conformity to cable shielding type isn't determine. Please check the settings.");
            }
        }

        /// <summary>
        /// Cable standart recommendation
        /// </summary>
        public string RecommendationCableStandart
        {
            get
            {
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.None)
                {
                    return RecommendationsAvailability_RecommendationCableStandart_None;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TenBASE_T)
                {
                    return RecommendationsAvailability_RecommendationCableStandart_TenBASE_T;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.FastEthernet)
                {
                    return RecommendationsAvailability_RecommendationCableStandart_FastEthernet;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.GigabitBASE_T)
                {
                    return RecommendationsAvailability_RecommendationCableStandart_GigabitBASE_T;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.GigabitBASE_TX)
                {
                    return RecommendationsAvailability_RecommendationCableStandart_GigabitBASE_TX;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TwoPointFiveGBASE_T)
                {
                    return RecommendationsAvailability_RecommendationCableStandart_TwoPointFiveGBASE_T;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.FiveGBASE_T)
                {
                    return RecommendationsAvailability_RecommendationCableStandart_FiveGBASE_T;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TenGE)
                {
                    return RecommendationsAvailability_RecommendationCableStandart_TenGE;
                }
                throw new SCSCalcException("The value of connection interface is not determine. Please check the settings");
            }
        }
    }
}
