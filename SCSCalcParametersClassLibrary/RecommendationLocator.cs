namespace SCSCalc.Parameters
{
    internal enum IsolationType
    {
        None = 0,
        Indoor = 1,
        Outdoor = 2
    }

    internal enum IsolationMaterial
    {
        None = 0,
        LSZH = 1,
        PVC = 2
    }

    internal enum ShieldedType
    {
        None = 0,
        UTP = 1,
        FTP = 2
    }

    internal enum ConnectionInterfaceStandard
    {
        None = 0,
        TenBASE_T = 1,
        FastEthernet = 2,
        GigabitBASE_T = 3,
        GigabitBASE_TX = 4,
        TwoPointFiveGBASE_T = 5,
        FiveGBASE_T = 6,
        TenGE = 7
    }

    internal interface IRecommendations
    {
        public IsolationType IsolationType { get; set; }
        public IsolationMaterial IsolationMaterial { get; set; }
        public ShieldedType ShieldedType { get; set; }
        public List<ConnectionInterfaceStandard> ConnectionInterfaces { get; set; }
        string RecommendationIsolationType { get; }
        string RecommendationIsolationMaterial { get; }
        string RecommendationShieldedType { get; }
        string RecommendationCableStandart { get; }
    }

    internal class RecommendationsAvailability : IRecommendations
    {
        public IsolationType IsolationType { get; set; }
        public IsolationMaterial IsolationMaterial { get; set; }
        public ShieldedType ShieldedType { get; set; }
        public List<ConnectionInterfaceStandard> ConnectionInterfaces { get; set; }

        public RecommendationsAvailability()
        {
            ConnectionInterfaces = new()
            {
                ConnectionInterfaceStandard.None
            };
        }

        public string RecommendationIsolationType
        {
            get
            {
                if (IsolationType == IsolationType.Indoor)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationType_Indoor;
                }
                if (IsolationType == IsolationType.Outdoor)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationType_Outdoor;
                }
                if (IsolationType == IsolationType.None)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationType_None;
                }
                throw new SCSCalcException("Соответствие типу изоляции не установлено. Пожалуйста, проверьте настройки.");
            }
        }

        public string RecommendationIsolationMaterial
        {
            get
            {
                if(IsolationMaterial == IsolationMaterial.None)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationMaterial_None;
                }
                if(IsolationMaterial == IsolationMaterial.LSZH)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationMaterial_LSZH;
                }
                if (IsolationMaterial == IsolationMaterial.PVC)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationIsolationMaterial_PVC;
                }
                throw new SCSCalcException("Соответствие материалу изоляции не установлено. Пожалуйста, проверьте настройки.");
            }
        }

        public string RecommendationShieldedType
        {
            get
            {
                if(ShieldedType == ShieldedType.None)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationShieldedType_None;
                }
                if (ShieldedType == ShieldedType.UTP)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationShieldedType_UTP;
                }
                if (ShieldedType == ShieldedType.FTP)
                {
                    return Properties.Resources.RecommendationsAvailability_RecommendationShieldedType_FTP;
                }
                throw new SCSCalcException("Соответствие типу экранизации не установлено. Пожалуйста, проверьте настройки.");
            }
        }

        public string RecommendationCableStandart
        {
            get
            {
                if(ConnectionInterfaces.Max() == ConnectionInterfaceStandard.None)
                {
                    return Properties.Resources.RecommendationsAvailabilityRecommendationCableStandart_None;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TenBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailabilityRecommendationCableStandart_TenBASE_T;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.FastEthernet)
                {
                    return Properties.Resources.RecommendationsAvailabilityRecommendationCableStandart_FastEthernet;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.GigabitBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailabilityRecommendationCableStandart_GigabitBASE_T;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.GigabitBASE_TX)
                {
                    return Properties.Resources.RecommendationsAvailabilityRecommendationCableStandart_GigabitBASE_TX;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TwoPointFiveGBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailabilityRecommendationCableStandart_TwoPointFiveGBASE_T;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.FiveGBASE_T)
                {
                    return Properties.Resources.RecommendationsAvailabilityRecommendationCableStandart_FiveGBASE_T;
                }
                if (ConnectionInterfaces.Max() == ConnectionInterfaceStandard.TenGE)
                {
                    return Properties.Resources.RecommendationsAvailabilityRecommendationCableStandart_TenGE;
                }
                throw new SCSCalcException("Значение интерфейса подключения не инициализировано. Пожалуйста, проверьте настройки.");
            }
        }
    }



    internal class NonRecommendations : IRecommendations
    {
        public IsolationType IsolationType { get; set; }
        public IsolationMaterial IsolationMaterial { get; set; }
        public ShieldedType ShieldedType { get; set; }
        public List<ConnectionInterfaceStandard> ConnectionInterfaces { get; set; }

        public NonRecommendations()
        {
            ConnectionInterfaces = new()
            {
                ConnectionInterfaceStandard.None
            };
        }

        public string RecommendationIsolationType
        {
            get
            {
                return Properties.Resources.NonRecommendations_RecommendationIsolationType;
            }
        }

        public string RecommendationIsolationMaterial
        {
            get
            {
                return Properties.Resources.NonRecommendations_RecommendationIsolationMaterial;
            }
        }

        public string RecommendationShieldedType
        {
            get
            {
                return Properties.Resources.NonRecommendations_RecommendationShieldedType;
            }
        }

        public string RecommendationCableStandart
        {
            get
            {
                return Properties.Resources.NonRecommendations_RecommendationCableStandart;
            }
        }
    }



    internal class RecommendationLocator
    {
        private IRecommendations? recommendations;

        public RecommendationLocator()
        {
            recommendations = null;
        }

        public void SetRecommendationsAvailability()
        {
            recommendations = new RecommendationsAvailability();
        }

        public void SetNonRecommendations()
        {
            recommendations = new NonRecommendations();
        }

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

        //Ты тут. Реализовать фурнкции добавления в лист ConnectionInterfaces и удаление из него. Подумать, как сделать лучше.

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
