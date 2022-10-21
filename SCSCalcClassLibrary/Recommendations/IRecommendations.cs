namespace SCSCalc
{
    /// <summary>
    /// Интерфейс для получения рекомендаций по побдору кабеля
    /// </summary>
    internal interface IRecommendations
    {
        /// <summary>
        /// Аргументы для получения рекомендаций по побдору кабеля
        /// </summary>
        RecommendationsArguments RecommendationsArguments { get; }

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
