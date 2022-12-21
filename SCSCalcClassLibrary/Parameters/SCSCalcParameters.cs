namespace SCSCalc.Parameters
{
    /// <summary>
    /// Класс, предоставляющий для других классов приложения доступ к настраиваемым параметрам вводимых значений конфигураций СКС.
    /// </summary>
    public class SCSCalcParameters
    {
        private DiapasonContext diapasonContext;
        private ValueContext valueContext;
        private RecommendationContext recommendationContext;

        public SCSCalcParameters()
        {
            diapasonContext = new();
            valueContext = new();
            recommendationContext = new();
        }

        /// <summary>
        /// Диапазоны вводимых значений параметров расчёта конфигураций СКС
        /// </summary>
        public SCSCalcDiapasons Diapasons
        {
            get => diapasonContext.Diapasons;
        }

        /// <summary>
        /// Рекомендации по подбору кабеля
        /// </summary>
        public CableSelectionRecommendations CableSelectionRecommendations
        {
            get => recommendationContext.CableSelectionRecommendations;
        }

        /// <summary>
        /// Значение коэффициента технологического запаса
        /// </summary>
        public double TechnologicalReserve
        {
            get => valueContext.TechnologicalReserve;
            set => valueContext.TechnologicalReserve = value;
        }

        /// <summary>
        /// Аргументы для получения рекомендаций по побдору кабеля
        /// </summary>
        public RecommendationsArguments RecommendationsArguments
        {
            get => recommendationContext.RecommendationsArguments;
        }

        /// <summary>
        /// Включено или выключено получение рекомендаций по побдору кабеля
        /// </summary>
        public bool? IsRecommendationsAvailability
        {
            get => recommendationContext.IsRecommendationsAvailability;
            set => recommendationContext.IsRecommendationsAvailability = value;
        }

        /// <summary>
        /// Разрешен или нет ввод значений в соответствии стандарту ISO/IEC 11801
        /// </summary>
        public bool? IsStrictСomplianceWithTheStandart
        {
            get => diapasonContext.IsStrictСomplianceWithTheStandart;
            set => diapasonContext.IsStrictСomplianceWithTheStandart = value;
        }

        /// <summary>
        /// Разрешен или нет произвольный ввод значений количества портов на 1 рабочее место
        /// </summary>
        public bool? IsAnArbitraryNumberOfPorts
        {
            get => diapasonContext.IsAnArbitraryNumberOfPorts;
            set => diapasonContext.IsAnArbitraryNumberOfPorts = value;
        }

        /// <summary>
        /// Учитывается или нет коэффициент технологического запаса
        /// </summary>
        public bool? IsTechnologicalReserveAvailability
        {
            get => valueContext.IsTechnologicalReserveAvailability;
            set => valueContext.IsTechnologicalReserveAvailability = value;
        }
    }
}