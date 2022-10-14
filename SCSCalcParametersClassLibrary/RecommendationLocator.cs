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
        /// Устанавливает значение получения рекомендации для кабеля внутреннего применения
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void SetRecommendationIndoorCable()
        {
            if (recommendations != null)
            {
                recommendations.IsolationType = IsolationType.Indoor;
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Устанавливает значение получения рекомендации для кабеля наружного применения
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void SetRecommendationOutdoorCable()
        {
            if (recommendations != null)
            {
                recommendations.IsolationType = IsolationType.Outdoor;
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Устанавливает значение получения рекомендации без учета норм пожарной безопасности
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void SetRecommendationNonLSZHCable()
        {
            if (recommendations != null)
            {
                recommendations.IsolationMaterial = IsolationMaterial.PVC;
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Устанавливает значение получения рекомендации для учета норм пожарной безопасности
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void SetRecommendationLSZHCable()
        {
            if (recommendations != null)
            {
                recommendations.IsolationMaterial = IsolationMaterial.LSZH;
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Устанавливает значение получения рекомендации для экранированного кабеля
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void SetRecommendationShieldedCable()
        {
            if (recommendations != null)
            {
                recommendations.ShieldedType = ShieldedType.FTP;
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Устанавливает значение получения рекомендации для неэкранированного кабеля
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void SetRecommendationNonShieldedCable()
        {
            if (recommendations != null)
            {
                recommendations.ShieldedType = ShieldedType.UTP;
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Добавляет отсутствующее значение интерфейса подключения
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void AddConnectionInterfaceStandardNone()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.Add(ConnectionInterfaceStandard.None);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 10BASE-T
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void AddConnectionInterfaceStandardTenBASE_T()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.Add(ConnectionInterfaceStandard.TenBASE_T);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта Fast Ethernet
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void AddConnectionInterfaceStandardFastEthernet()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.Add(ConnectionInterfaceStandard.FastEthernet);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 1000BASE-T
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void AddConnectionInterfaceStandardGigabitBASE_T()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.Add(ConnectionInterfaceStandard.GigabitBASE_T);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 1000BASE-TX 
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void AddConnectionInterfaceStandardGigabitBASE_TX()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.Add(ConnectionInterfaceStandard.GigabitBASE_TX);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 2.5GBASE-T
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void AddConnectionInterfaceStandardTwoPointFiveGBASE_T()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.Add(ConnectionInterfaceStandard.TwoPointFiveGBASE_T);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 5GBASE-T
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void AddConnectionInterfaceStandardFiveGBASE_T()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.Add(ConnectionInterfaceStandard.FiveGBASE_T);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 10GBASE-T
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void AddConnectionInterfaceStandardTenGE()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.Add(ConnectionInterfaceStandard.TenGE);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Удаление из списка планируемых подключений отстуствующее значение
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void RemoveConnectionInterfaceStandardNone()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.RemoveAll(t => t == ConnectionInterfaceStandard.None);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 10BASE-T
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void RemoveConnectionInterfaceStandardTenBASE_T()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.RemoveAll(t => t == ConnectionInterfaceStandard.TenBASE_T);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта Fast Ethernet
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void RemoveConnectionInterfaceStandardFastEthernet()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.RemoveAll(t => t == ConnectionInterfaceStandard.FastEthernet);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 1000BASE-T
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void RemoveConnectionInterfaceStandardGigabitBASE_T()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.RemoveAll(t => t == ConnectionInterfaceStandard.GigabitBASE_T);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 1000BASE-TX
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void RemoveConnectionInterfaceStandardGigabitBASE_TX()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.RemoveAll(t => t == ConnectionInterfaceStandard.GigabitBASE_TX);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 2.5GBASE-T
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void RemoveConnectionInterfaceStandardTwoPointFiveGBASE_T()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.RemoveAll(t => t == ConnectionInterfaceStandard.TwoPointFiveGBASE_T);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 5GBASE-T
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void RemoveConnectionInterfaceStandardFiveGBASE_T()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.RemoveAll(t => t == ConnectionInterfaceStandard.FiveGBASE_T);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
            }
        }

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 10GBASE-T
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public void RemoveConnectionInterfaceStandardTenGE()
        {
            if (recommendations != null)
            {
                recommendations.ConnectionInterfaces.RemoveAll(t => t == ConnectionInterfaceStandard.FiveGBASE_T);
            }
            else
            {
                throw new SCSCalcException("Значение получения рекомендаций по подбору кабеля не инициализировано. Пожалуйста, проверьте настройки");
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
