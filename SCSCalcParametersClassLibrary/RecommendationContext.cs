namespace SCSCalc.Parameters
{
    /// <summary>
    /// Encapsulates objects which intended for work with getting of cable selection recommendations
    /// </summary>
    internal class RecommendationContext
    {
        private IRecommendationsStrategy? recommendationsStrategy;
        private RecommendationsAvailabilityStrategy recommendationsAvailability;
        private NonRecommendationsStrategy nonRecommendations;

        public RecommendationContext()
        {
            recommendationsStrategy = null;
            recommendationsAvailability = new();
            nonRecommendations = new();
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
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
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
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
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
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
            set
            {
                if (Equals(value, true))
                {
                    recommendationsStrategy = recommendationsAvailability;
                }
                else
                {
                    recommendationsStrategy = nonRecommendations;
                }
            }
        }
    }
}
