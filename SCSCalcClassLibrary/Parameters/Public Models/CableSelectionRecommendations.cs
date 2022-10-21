namespace SCSCalc.Parameters
{
    /// <summary>
    /// Класс, представляющий рекомендации по подбору кабеля
    /// </summary>
    public class CableSelectionRecommendations
    {
        /// <summary>
        /// Рекомендация по типу изоляции кабеля
        /// </summary>
        public string? RecommendationIsolationType { get; init; }

        /// <summary>
        /// Рекомендация по материалу изоляции кабеля
        /// </summary>
        public string? RecommendationIsolationMaterial { get; init; }

        /// <summary>
        /// Рекомендация по типу экранизации кабеля
        /// </summary>
        public string? RecommendationShieldedType { get; init; }

        /// <summary>
        /// Рекомендация по стандарту кабеля
        /// </summary>
        public string? RecommendationCableStandart { get; init; }
    }
}
