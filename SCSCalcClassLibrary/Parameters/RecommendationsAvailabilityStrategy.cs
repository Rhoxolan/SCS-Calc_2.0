using static SCSCalc.Properties.Resources;

namespace SCSCalc.Parameters
{
    /// <summary>
    /// Класс для получения рекомендаций по побдору кабеля при включенном получении рекомендаций
    /// </summary>
    internal class RecommendationsAvailabilityStrategy : IRecommendationsStrategy
    {
        /// <summary>
        /// Аргументы для получения рекомендаций по побдору кабеля
        /// </summary>
        public RecommendationsArguments RecommendationsArguments { get; } = new();

        /// <summary>
        /// Рекомендация по типу изоляции кабеля
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
                throw new SCSCalcException("Соответствие типу изоляции не установлено. Пожалуйста, проверьте настройки.");
            }
        }

        /// <summary>
        /// Рекомендация по материалу изоляции кабеля
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
                throw new SCSCalcException("Соответствие материалу изоляции не установлено. Пожалуйста, проверьте настройки.");
            }
        }

        /// <summary>
        /// Рекомендация по типу экранизации кабеля
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
                throw new SCSCalcException("Соответствие типу экранизации не установлено. Пожалуйста, проверьте настройки.");
            }
        }

        /// <summary>
        /// Рекомендация по стандарту кабеля
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
                throw new SCSCalcException("Значение интерфейса подключения не инициализировано. Пожалуйста, проверьте настройки.");
            }
        }
    }
}
