namespace SCSCalc.Parameters
{
    // Класс, инкапсулирующий объекты для работы с получением рекомендаций по побдору кабеля

    /// <summary>
    /// //Класс, инкапсулирующий объекты для работы с получением рекомендаций по побдору кабеля
    /// </summary>
    internal class RecommendationLocator
    {
        private IRecommendations? recommendations;

        public RecommendationLocator()
        {
            recommendations = null;
        }

        /// <summary>
        /// Устанавливает получение рекомендаций
        /// </summary>
        public void SetRecommendationsAvailability()
        {
            recommendations = new RecommendationsAvailability();
        }

        /// <summary>
        /// Отключает получение рекомендаций
        /// </summary>
        public void SetNonRecommendations()
        {
            recommendations = new NonRecommendations();
        }

        /// <summary>
        /// Тип изоляции рекомендуемого кабеля
        /// </summary>
        public IsolationType IsolationType
        {
            get
            {
                if(recommendations != null)
                {
                    return recommendations.IsolationType;
                }
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
            set
            {
                if(recommendations == null)
                {
                    throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
                }
                recommendations.IsolationType = value;
            }
        }

        /// <summary>
        /// Материал изоляции рекомендуемого кабеля
        /// </summary>
        public IsolationMaterial IsolationMaterial
        {
            get
            {
                if (recommendations != null)
                {
                    return recommendations.IsolationMaterial;
                }
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
            set
            {
                if (recommendations == null)
                {
                    throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
                }
                recommendations.IsolationMaterial = value;
            }
        }

        /// <summary>
        /// Тип экранизации рекомендуемого кабеля
        /// </summary>
        public ShieldedType ShieldedType
        {
            get
            {
                if (recommendations != null)
                {
                    return recommendations.ShieldedType;
                }
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
            set
            {
                if (recommendations == null)
                {
                    throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
                }
                recommendations.ShieldedType = value;
            }
        }

        /// <summary>
        /// Список планируемых интерфейсов подключений
        /// </summary>
        public List<ConnectionInterfaceStandard> ConnectionInterfaces
        {
            get
            {
                if (recommendations != null)
                {
                    return recommendations.ConnectionInterfaces;
                }
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
            set
            {
                if (recommendations == null)
                {
                    throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
                }
                recommendations.ConnectionInterfaces = value;
            }
        }

        /// <summary>
        /// Включено или выключено получение рекомендаций по побдору кабеля
        /// </summary>
        public bool IsRecommendationsAvailability
        {
            get
            {
                if(recommendations is RecommendationsAvailability)
                {
                    return true;
                }
                if(recommendations is NonRecommendations)
                {
                    return false;
                }
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }
    }
}
