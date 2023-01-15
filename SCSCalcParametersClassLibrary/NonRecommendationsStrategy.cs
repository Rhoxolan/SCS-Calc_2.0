using static SCSCalc.Parameters.Properties.Resources;

namespace SCSCalc.Parameters
{
    /// <summary>
    /// Class for getting cable selection recommendations if getting recommendations is disabled
    /// </summary>
    internal class NonRecommendationsStrategy : IRecommendationsStrategy
    {
        /// <summary>
        /// Arguments for getting cable selection recommendations
        /// </summary>
        public RecommendationsArguments RecommendationsArguments { get; } = new();

        /// <summary>
        /// Cable insulation type recommendation
        /// </summary>
        public string RecommendationIsolationType
            => NonRecommendations_RecommendationIsolationType;

        /// <summary>
        /// Cable insulation material recommendation
        /// </summary>
        public string RecommendationIsolationMaterial
            => NonRecommendations_RecommendationIsolationMaterial;

        /// <summary>
        /// Cable shielding type recommendation
        /// </summary>
        public string RecommendationShieldedType
            => NonRecommendations_RecommendationShieldedType;

        /// <summary>
        /// Cable standart recommendation
        /// </summary>
        public string RecommendationCableStandart
            => NonRecommendations_RecommendationCableStandart;
    }
}
