using static SCSCalc.Properties.Resources;

namespace SCSCalc.Parameters
{
    /// <summary>
    /// Класс для получения рекомендаций по побдору кабеля при отключенном получении рекомендаций
    /// </summary>
    internal class NonRecommendations : IRecommendations
    {
        /// <summary>
        /// Аргументы для получения рекомендаций по побдору кабеля
        /// </summary>
        public RecommendationsArguments RecommendationsArguments { get; } = new();

        /// <summary>
        /// Рекомендация по типу изоляции кабеля
        /// </summary>
        public string RecommendationIsolationType
            => NonRecommendations_RecommendationIsolationType;

        /// <summary>
        /// Рекомендация по материалу изоляции кабеля
        /// </summary>
        public string RecommendationIsolationMaterial
            => NonRecommendations_RecommendationIsolationMaterial;

        /// <summary>
        /// Рекомендация по типу экранизации кабеля
        /// </summary>
        public string RecommendationShieldedType
            => NonRecommendations_RecommendationShieldedType;

        /// <summary>
        /// Рекомендация по стандарту кабеля
        /// </summary>
        public string RecommendationCableStandart
            => NonRecommendations_RecommendationCableStandart;
    }
}
