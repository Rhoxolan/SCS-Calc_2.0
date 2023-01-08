namespace SCSCalc.Parameters
{
    /// <summary>
    /// Presents cable selection recommendations
    /// </summary>
    public class CableSelectionRecommendations
    {
        /// <summary>
        /// Сable insulation type recommendation
        /// </summary>
        public required string RecommendationIsolationType { get; init; }

        /// <summary>
        /// Cable insulation material recommendation
        /// </summary>
        public required string RecommendationIsolationMaterial { get; init; }

        /// <summary>
        /// Cable shielding type recommendation
        /// </summary>
        public required string RecommendationShieldedType { get; init; }

        /// <summary>
        /// Cable standard recommendation
        /// </summary>
        public required string RecommendationCableStandard { get; init; }
    }
}
