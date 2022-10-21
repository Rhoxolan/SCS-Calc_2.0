namespace SCSCalc
{
    /// <summary>
    /// Класс для получения рекомендаций по побдору кабеля при включенном получении рекомендаций
    /// </summary>
    internal class RecommendationsAvailability : IRecommendations
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
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationType_Indoor;
                }
                if (RecommendationsArguments.IsolationType == IsolationType.Outdoor)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationType_Outdoor;
                }
                if (RecommendationsArguments.IsolationType == IsolationType.None)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationType_None;
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
                if(RecommendationsArguments.IsolationMaterial == IsolationMaterial.None)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationMaterial_None;
                }
                if(RecommendationsArguments.IsolationMaterial == IsolationMaterial.LSZH)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationMaterial_LSZH;
                }
                if (RecommendationsArguments.IsolationMaterial == IsolationMaterial.PVC)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationMaterial_PVC;
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
                if(RecommendationsArguments.ShieldedType == ShieldedType.None)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationShieldedType_None;
                }
                if (RecommendationsArguments.ShieldedType == ShieldedType.UTP)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationShieldedType_UTP;
                }
                if (RecommendationsArguments.ShieldedType == ShieldedType.FTP)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationShieldedType_FTP;
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
                if(RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.None)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_None;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TenBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_TenBASE_T;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.FastEthernet)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_FastEthernet;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.GigabitBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_GigabitBASE_T;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.GigabitBASE_TX)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_GigabitBASE_TX;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TwoPointFiveGBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_TwoPointFiveGBASE_T;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.FiveGBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_FiveGBASE_T;
                }
                if (RecommendationsArguments.ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TenGE)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_TenGE;
                }
                throw new SCSCalcException("Значение интерфейса подключения не инициализировано. Пожалуйста, проверьте настройки.");
            }
        }
    }
}
