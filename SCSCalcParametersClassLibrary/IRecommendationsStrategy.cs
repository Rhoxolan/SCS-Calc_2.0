namespace SCSCalc.Parameters
{
    /// <summary>
    /// Interface for getting cable selection recommendations
    /// </summary>
    internal interface IRecommendationsStrategy
    {
        /// <summary>
        /// Arguments for getting cable selection recommendations
        /// </summary>
        RecommendationsArguments RecommendationsArguments { get; }

        /// <summary>
        /// Cable insulation type recommendation
        /// </summary>
        string RecommendationIsolationType { get; }

        /// <summary>
        /// Cable insulation material recommendation
        /// </summary>
        string RecommendationIsolationMaterial { get; }

        /// <summary>
        /// Cable shielding type recommendation
        /// </summary>
        string RecommendationShieldedType { get; }

        /// <summary>
        /// Cable standart recommendation
        /// </summary>
        string RecommendationCableStandart { get; }
    }
}
