namespace SCSCalc.Parameters
{
    /// <summary>
    /// //Класс, инкапсулирующий объекты для работы с получением рекомендаций по побдору кабеля
    /// </summary>
    internal class RecommendationLocator
    {
        private IRecommendations? recommendations;

        public RecommendationLocator()
        {
            IsRecommendationsAvailability = null;
            recommendations = null;
        }

        /// <summary>
        /// Рекомендации по подбору кабеля
        /// </summary>
        public CableSelectionRecommendations CableSelectionRecommendations
        {
            get
            {
                if (recommendations != null)
                {
                    return new CableSelectionRecommendations
                    {
                        RecommendationIsolationType = recommendations.RecommendationIsolationType,
                        RecommendationIsolationMaterial = recommendations.RecommendationIsolationMaterial,
                        RecommendationCableStandart = recommendations.RecommendationCableStandart,
                        RecommendationShieldedType = recommendations.RecommendationShieldedType
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
                if (recommendations != null)
                {
                    return recommendations.RecommendationsArguments;
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
                if (recommendations is RecommendationsAvailability)
                {
                    return true;
                }
                if (recommendations is NonRecommendations)
                {
                    return false;
                }
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
            set
            {
                if (Equals(value, true))
                {
                    recommendations = new RecommendationsAvailability();
                }
                else
                {
                    recommendations = new NonRecommendations();
                }
            }
        }
    }
}
