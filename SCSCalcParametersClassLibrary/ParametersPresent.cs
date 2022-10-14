namespace SCSCalc.Parameters
{
    /// <summary>
    /// Класс, предоставляющий для других классов приложения доступ к настраиваемым параметрам вводимых значений конфигураций СКС.
    /// </summary>
    public class ParametersPresent
    {
        private DiapasonLocator diapasonLocator;
        private ValueLocator valueLocator;
        private RecommendationLocator recommendationLocator;

        public ParametersPresent()
        {
            diapasonLocator = new();
            valueLocator = new();
            recommendationLocator = new();
        }

        public static void ParametersSerializer(ParametersPresent parametersPresent, string ParametersDocPath)
        {

        }

        /// <summary>
        /// Диапазоны вводимых значений параметров расчёта конфигураций СКС
        /// </summary>
        public ((decimal Min, decimal Max) MinPermanentLinkDiapason, (decimal Min, decimal Max) MaxPermanentLinkDiapason, (decimal Min, decimal Max) NumberOfPortsDiapason,
            (decimal Min, decimal Max) NumberOfWorkplacesDiapason, (decimal Min, decimal Max) CableHankMeterageDiapason, (decimal Min, decimal Max) TechnologicalReserveDiapason) Diapasons
        {
            get
            {
                return (diapasonLocator.MinPermanentLinkDiapason, diapasonLocator.MaxPermanentLinkDiapason, diapasonLocator.NumberOfPortsDiapason,
                    diapasonLocator.NumberOfWorkplacesDiapason, diapasonLocator.CableHankMeterageDiapason, diapasonLocator.TechnologicalReserveDiapason);
            }
        }

        /// <summary>
        /// Значение коэффициента технологического запаса
        /// </summary>
        public double TechnologicalReserve
        {
            get => valueLocator.TechnologicalReserve;
            set => valueLocator.TechnologicalReserve = value;
        }

        /// <summary>
        /// Устанавливает соответствие вводимых значений стандарту ISO/IEC 11801
        /// </summary>
        public void SetStrictСomplianceWithTheStandart() => diapasonLocator.SetStrictСomplianceWithTheStandart();

        /// <summary>
        /// Разрешает ввод значений без соответствия стандарту ISO/IEC 11801
        /// </summary>
        public void SetNonStrictСomplianceWithTheStandart() => diapasonLocator.SetNonStrictСomplianceWithTheStandart();

        /// <summary>
        /// Устанавливает ввод значения количества портов на 1 рабочее место в соответствии стандарту ISO/IEC 11801
        /// </summary>
        public void SetNotAnArbitraryNumberOfPorts() => diapasonLocator.SetNotAnArbitraryNumberOfPorts();

        /// <summary>
        /// Разрешает произвольный ввод значения количества портов на 1 рабочее место без соответствия стандарту ISO/IEC 11801
        /// </summary>
        public void SetAnArbitraryNumberOfPorts() => diapasonLocator.SetAnArbitraryNumberOfPorts();

        /// <summary>
        /// Устанавливает учёт технологического запаса
        /// </summary>
        public void SetTechnologicalReserveAvailability() => valueLocator.SetTechnologicalReserveAvailability();

        /// <summary>
        /// Расчёт без учёта технологического запаса
        /// </summary>
        public void SetNonTechnologicalReserve() => valueLocator.SetNonTechnologicalReserve();

        /// <summary>
        /// Устанавливает получение рекомендаций
        /// </summary>
        public void SetRecommendationsAvailability() => recommendationLocator.SetRecommendationsAvailability();

        /// <summary>
        /// Отключает получение рекомендаций
        /// </summary>
        public void SetNonRecommendations() => recommendationLocator.SetNonRecommendations();

        /// <summary>
        /// Устанавливает значение получения рекомендации для кабеля внутреннего применения
        /// </summary>
        public void SetRecommendationIndoorCable() => recommendationLocator.SetRecommendationIndoorCable();

        /// <summary>
        /// Устанавливает значение получения рекомендации для кабеля наружного применения
        /// </summary>
        public void SetRecommendationOutdoorCable() => recommendationLocator.SetRecommendationOutdoorCable();

        /// <summary>
        /// Устанавливает значение получения рекомендации без учета норм пожарной безопасности
        /// </summary>
        public void SetRecommendationNonLSZHCable() => recommendationLocator.SetRecommendationNonLSZHCable();

        /// <summary>
        /// Устанавливает значение получения рекомендации для учета норм пожарной безопасности
        /// </summary>
        public void SetRecommendationLSZHCable() => recommendationLocator.SetRecommendationLSZHCable();

        /// <summary>
        /// Устанавливает значение получения рекомендации для экранированного кабеля
        /// </summary>
        public void SetRecommendationShieldedCable() => recommendationLocator.SetRecommendationShieldedCable();

        /// <summary>
        /// Устанавливает значение получения рекомендации для неэкранированного кабеля
        /// </summary>
        public void SetRecommendationNonShieldedCable() => recommendationLocator.SetRecommendationNonShieldedCable();

        /// <summary>
        /// Добавляет отсутствующее значение интерфейса подключения
        /// </summary>
        public void AddConnectionInterfaceStandardNone() => recommendationLocator.AddConnectionInterfaceStandardNone();

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 10BASE-T
        /// </summary>
        public void AddConnectionInterfaceStandardTenBASE_T() => recommendationLocator.AddConnectionInterfaceStandardTenBASE_T();

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта Fast Ethernet
        /// </summary>
        public void AddConnectionInterfaceStandardFastEthernet() => recommendationLocator.AddConnectionInterfaceStandardFastEthernet();

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 1000BASE-T
        /// </summary>
        public void AddConnectionInterfaceStandardGigabitBASE_T() => recommendationLocator.AddConnectionInterfaceStandardGigabitBASE_T();

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 1000BASE-TX 
        /// </summary>
        public void AddConnectionInterfaceStandardGigabitBASE_TX() => recommendationLocator.AddConnectionInterfaceStandardGigabitBASE_TX();

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 2.5GBASE-T
        /// </summary>
        public void AddConnectionInterfaceStandardTwoPointFiveGBASE_T() => recommendationLocator.AddConnectionInterfaceStandardTwoPointFiveGBASE_T();

        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 5GBASE-T
        /// </summary>
        public void AddConnectionInterfaceStandardFiveGBASE_T() => recommendationLocator.AddConnectionInterfaceStandardFiveGBASE_T();


        /// <summary>
        /// Добавляет значение планируемого интерфейса подключения стандарта 10GBASE-T
        /// </summary>
        public void AddConnectionInterfaceStandardTenGE() => recommendationLocator.AddConnectionInterfaceStandardTenGE();

        /// <summary>
        /// Удаление из списка планируемых подключений отстуствующее значение
        /// </summary>
        public void RemoveConnectionInterfaceStandardNone() => recommendationLocator.AddConnectionInterfaceStandardTenGE();

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 10BASE-T
        /// </summary>
        public void RemoveConnectionInterfaceStandardTenBASE_T() => recommendationLocator.RemoveConnectionInterfaceStandardTenBASE_T();

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта Fast Ethernet
        /// </summary>
        public void RemoveConnectionInterfaceStandardFastEthernet() => recommendationLocator.RemoveConnectionInterfaceStandardFastEthernet();

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 1000BASE-T
        /// </summary>
        public void RemoveConnectionInterfaceStandardGigabitBASE_T() => recommendationLocator.RemoveConnectionInterfaceStandardTenBASE_T();

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 1000BASE-TX
        /// </summary>
        public void RemoveConnectionInterfaceStandardGigabitBASE_TX() => recommendationLocator.RemoveConnectionInterfaceStandardGigabitBASE_TX();

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 2.5GBASE-T
        /// </summary>
        public void RemoveConnectionInterfaceStandardTwoPointFiveGBASE_T() => recommendationLocator.RemoveConnectionInterfaceStandardTwoPointFiveGBASE_T();

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 5GBASE-T
        /// </summary>
        public void RemoveConnectionInterfaceStandardFiveGBASE_T() => recommendationLocator.RemoveConnectionInterfaceStandardFiveGBASE_T();

        /// <summary>
        /// Удаление из списка планируемых подключений значение стандарта 10GBASE-T
        /// </summary>
        public void RemoveConnectionInterfaceStandardTenGE() => recommendationLocator.RemoveConnectionInterfaceStandardTenGE();

        /// <summary>
        /// Включено или выключено получение рекомендаций по побдору кабеля
        /// </summary>
        public bool IsRecommendationsAvailability
        {
            get => recommendationLocator.IsRecommendationsAvailability;
        }

        /// <summary>
        /// Разрешен или нет ввод значений в соответствии стандарту ISO/IEC 11801
        /// </summary>
        public bool IsStrictСomplianceWithTheStandart
        {
            get => diapasonLocator.IsStrictСomplianceWithTheStandart;
        }

        /// <summary>
        /// Разрешен или нет произвольный ввод значений количества портов на 1 рабочее место
        /// </summary>
        public bool IsAnArbitraryNumberOfPorts
        {
            get => diapasonLocator.IsAnArbitraryNumberOfPorts;
        }

        /// <summary>
        /// Учитывается или нет коэффициент технологического запаса
        /// </summary>
        public bool IsTechnologicalReserveAvailability
        {
            get => valueLocator.IsTechnologicalReserveAvailability;
        }
    }
}