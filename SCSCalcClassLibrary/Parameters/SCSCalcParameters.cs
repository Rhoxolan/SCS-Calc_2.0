namespace SCSCalc.Parameters
{
    //Класс имеет неполную реализацию. Наследники должны содержать методы по считыванию/сохранению данных настраиваемых параметров
    //вводимых значений конфигураций СКС, нацеленных на определенную платформу.

    /// <summary>
    /// Абстрактный класс, предоставляющий для других классов приложения доступ к настраиваемым параметрам вводимых значений конфигураций СКС.
    /// </summary>
    public abstract class SCSCalcParameters
    {
        private DiapasonLocator diapasonLocator;
        private ValueLocator valueLocator;
        private RecommendationLocator recommendationLocator;

        public SCSCalcParameters()
        {
            diapasonLocator = new();
            valueLocator = new();
            recommendationLocator = new();
        }

        /// <summary>
        /// Диапазоны вводимых значений параметров расчёта конфигураций СКС
        /// </summary>
        public SCSCalcDiapasons Diapasons
        {
            get => diapasonLocator.Diapasons;
        }

        /// <summary>
        /// Рекомендации по подбору кабеля
        /// </summary>
        public CableSelectionRecommendations CableSelectionRecommendations
        {
            get => recommendationLocator.CableSelectionRecommendations;
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
        /// Аргументы для получения рекомендаций по побдору кабеля
        /// </summary>
        public RecommendationsArguments RecommendationsArguments
        {
            get => recommendationLocator.RecommendationsArguments;
        }

        /// <summary>
        /// Включено или выключено получение рекомендаций по побдору кабеля
        /// </summary>
        public bool? IsRecommendationsAvailability
        {
            get => recommendationLocator.IsRecommendationsAvailability;
            set => recommendationLocator.IsRecommendationsAvailability = value;
        }

        /// <summary>
        /// Разрешен или нет ввод значений в соответствии стандарту ISO/IEC 11801
        /// </summary>
        public bool? IsStrictСomplianceWithTheStandart
        {
            get => diapasonLocator.IsStrictСomplianceWithTheStandart;
            set => diapasonLocator.IsStrictСomplianceWithTheStandart = value;
        }

        /// <summary>
        /// Разрешен или нет произвольный ввод значений количества портов на 1 рабочее место
        /// </summary>
        public bool? IsAnArbitraryNumberOfPorts
        {
            get => diapasonLocator.IsAnArbitraryNumberOfPorts;
            set => diapasonLocator.IsAnArbitraryNumberOfPorts = value;
        }

        /// <summary>
        /// Учитывается или нет коэффициент технологического запаса
        /// </summary>
        public bool? IsTechnologicalReserveAvailability
        {
            get => valueLocator.IsTechnologicalReserveAvailability;
            set => valueLocator.IsTechnologicalReserveAvailability = value;
        }
    }
}