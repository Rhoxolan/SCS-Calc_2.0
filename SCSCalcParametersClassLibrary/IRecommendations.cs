namespace SCSCalc.Parameters
{
    //Интерфейс для получения рекомендаций по побдору кабеля

    /// <summary>
    /// Интерфейс для получения рекомендаций по побдору кабеля
    /// </summary>
    internal interface IRecommendations
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

        /// <summary>
        /// Рекомендация по типу изоляции кабеля
        /// </summary>
        string RecommendationIsolationType { get; }

        /// <summary>
        /// Рекомендация по материалу изоляции кабеля
        /// </summary>
        string RecommendationIsolationMaterial { get; }

        /// <summary>
        /// Рекомендация по типу экранизации кабеля
        /// </summary>
        string RecommendationShieldedType { get; }

        /// <summary>
        /// Рекомендация по стандарту кабеля
        /// </summary>
        string RecommendationCableStandart { get; }
    }
}
