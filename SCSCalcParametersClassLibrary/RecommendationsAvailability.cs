namespace SCSCalc.Parameters
{
    // Класс для получения рекомендаций по побдору кабеля при включенном получении рекомендаций

    /// <summary>
    /// Класс для получения рекомендаций по побдору кабеля при включенном получении рекомендаций
    /// </summary>
    internal class RecommendationsAvailability : IRecommendations
    {
        /// <summary>
        /// Тип изоляции рекомендуемого кабеля
        /// </summary>
        public IsolationType IsolationType { get; set; }

        /// <summary>
        /// Материал изоляции рекомендуемого кабеля
        /// </summary>
        public IsolationMaterial IsolationMaterial { get; set; }

        /// <summary>
        /// Тип экранизации рекомендуемого кабеля
        /// </summary>
        public ShieldedType ShieldedType { get; set; }

        /// <summary>
        /// Список планируемых интерфейсов подключений
        /// </summary>
        public List<ConnectionInterfaceStandard> ConnectionInterfaces { get; set; }

        public RecommendationsAvailability()
        {
            ConnectionInterfaces = new()
            {
                ConnectionInterfaceStandard.None
            };
        }

        /// <summary>
        /// Рекомендация по типу изоляции кабеля
        /// </summary>
        public string RecommendationIsolationType
        {
            get
            {
                if (IsolationType == IsolationType.Indoor)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationType_Indoor;
                }
                if (IsolationType == IsolationType.Outdoor)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationType_Outdoor;
                }
                if (IsolationType == IsolationType.None)
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
                if(IsolationMaterial == IsolationMaterial.None)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationMaterial_None;
                }
                if(IsolationMaterial == IsolationMaterial.LSZH)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationMaterial_LSZH;
                }
                if (IsolationMaterial == IsolationMaterial.PVC)
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
                if(ShieldedType == ShieldedType.None)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationShieldedType_None;
                }
                if (ShieldedType == ShieldedType.UTP)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationShieldedType_UTP;
                }
                if (ShieldedType == ShieldedType.FTP)
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
                if(ConnectionInterfaces.Max() == ConnectionInterfaceStandard.None)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_None;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TenBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_TenBASE_T;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.FastEthernet)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_FastEthernet;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.GigabitBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_GigabitBASE_T;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.GigabitBASE_TX)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_GigabitBASE_TX;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TwoPointFiveGBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_TwoPointFiveGBASE_T;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.FiveGBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_FiveGBASE_T;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TenGE)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationCableStandart_TenGE;
                }
                throw new SCSCalcException("Значение интерфейса подключения не инициализировано. Пожалуйста, проверьте настройки.");
            }
        }
    }
}
