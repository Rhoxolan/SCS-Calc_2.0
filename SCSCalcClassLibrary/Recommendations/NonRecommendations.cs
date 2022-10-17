namespace SCSCalc
{
    // Класс для получения рекомендаций по побдору кабеля при отключенном получении рекомендаций

    /// <summary>
    /// Класс для получения рекомендаций по побдору кабеля при отключенном получении рекомендаций
    /// </summary>
    internal class NonRecommendations : IRecommendations
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

        public NonRecommendations()
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
                return Properties.Resources.NonRecommendations_RecommendationIsolationType;
            }
        }

        /// <summary>
        /// Рекомендация по материалу изоляции кабеля
        /// </summary>
        public string RecommendationIsolationMaterial
        {
            get
            {
                return Properties.Resources.NonRecommendations_RecommendationIsolationMaterial;
            }
        }

        /// <summary>
        /// Рекомендация по типу экранизации кабеля
        /// </summary>
        public string RecommendationShieldedType
        {
            get
            {
                return Properties.Resources.NonRecommendations_RecommendationShieldedType;
            }
        }

        /// <summary>
        /// Рекомендация по стандарту кабеля
        /// </summary>
        public string RecommendationCableStandart
        {
            get
            {
                return Properties.Resources.NonRecommendations_RecommendationCableStandart;
            }
        }
    }
}
