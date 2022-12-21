namespace SCSCalc.Parameters
{
    /// <summary>
    /// //Класс, инкапсулирующий объекты для работы с получением рекомендаций по побдору кабеля
    /// </summary>
    internal class RecommendationContext
    {
        private IRecommendationsStrategy? recommendationsStrategy;

        public RecommendationContext()
        {
            IsRecommendationsAvailability = null;
            recommendationsStrategy = null;
        }

        /// <summary>
        /// Рекомендации по подбору кабеля
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
                        RecommendationCableStandart = recommendationsStrategy.RecommendationCableStandart,
                        RecommendationShieldedType = recommendationsStrategy.RecommendationShieldedType
                    };
                }
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Аргументы для получения рекомендаций по побдору кабеля
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
        /// Включено или выключено получение рекомендаций по побдору кабеля
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
