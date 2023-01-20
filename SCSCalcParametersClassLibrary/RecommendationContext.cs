namespace SCSCalc.Parameters
{
    /// <summary>
    /// Encapsulates objects which intended for work with getting of cable selection recommendations
    /// </summary>
    internal class RecommendationContext
    {
        private IRecommendationsStrategy? recommendationsStrategy;

        public RecommendationContext()
        {
            recommendationsStrategy = null;
        }

        /// <summary>
        /// Cable selection recommandations
        /// </summary>
        public CableSelectionRecommendations CableSelectionRecommendations
        {
            get
            {
                if (recommendationsStrategy != null)
                {
                    return new CableSelectionRecommendations
                    {
                        RecommendationIsolationType = recommendationsStrategy.RecommendationIsolationType,
                        RecommendationIsolationMaterial = recommendationsStrategy.RecommendationIsolationMaterial,
                        RecommendationCableStandard = recommendationsStrategy.RecommendationCableStandart,
                        RecommendationShieldedType = recommendationsStrategy.RecommendationShieldedType
                    };
                }
                throw new SCSCalcException("The value of getting cable selection recommendations necessity is not initialized. Please check the settings");
            }
        }

        /// <summary>
        /// Arguments for getting of cable selection recommendations
        /// </summary>
        public RecommendationsArguments RecommendationsArguments
        {
            get
            {
                if (recommendationsStrategy != null)
                {
                    return recommendationsStrategy.RecommendationsArguments;
                }
                throw new SCSCalcException("The value of getting cable selection recommendations necessity is not initialized. Please check the settings");
            }
        }

        /// <summary>
        /// Enabled or disabled getting cable selection recommendations
        /// </summary>
        public bool? IsRecommendationsAvailability
        {
            get
            {
                if (recommendationsStrategy is RecommendationsAvailabilityStrategy)
                {
                    return true;
                }
                if (recommendationsStrategy is NonRecommendationsStrategy)
                {
                    return false;
                }
                throw new SCSCalcException("The value of getting cable selection recommendations necessity is not initialized. Please check the settings");
            }
            set
            {
                if (Equals(value, true))
                {
                    recommendationsStrategy = new RecommendationsAvailabilityStrategy();
                }
                else
                {
                    recommendationsStrategy = new NonRecommendationsStrategy();
                }
            }
        }
    }
}
