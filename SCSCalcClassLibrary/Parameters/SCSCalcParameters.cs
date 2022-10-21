using System.Text.Json;

namespace SCSCalc.Parameters
{
    /// <summary>
    /// Класс, предоставляющий для других классов приложения доступ к настраиваемым параметрам вводимых значений конфигураций СКС.
    /// </summary>
    public class SCSCalcParameters
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
        /// Сериализация настраеваемых параметров расчёта конфигураций СКС
        /// </summary>
        /// <param name="parametersPresent"></param>
        /// <param name="parametersDocPath"></param>
        public static void ParametersSerializer(SCSCalcParameters parametersPresent, string parametersDocPath)
        {
            (bool? IsStrictСomplianceWithTheStandart,
                bool? IsAnArbitraryNumberOfPorts,
                bool? IsTechnologicalReserveAvailability,
                bool? IsRecommendationsAvailability,
                double TechnologicalReserve,
                RecommendationsArguments RecommendationsArguments) parameters = new()
                {
                    IsStrictСomplianceWithTheStandart = parametersPresent.IsStrictСomplianceWithTheStandart,
                    IsAnArbitraryNumberOfPorts = parametersPresent.IsAnArbitraryNumberOfPorts,
                    IsTechnologicalReserveAvailability = parametersPresent.IsTechnologicalReserveAvailability,
                    IsRecommendationsAvailability = parametersPresent.IsRecommendationsAvailability,
                    TechnologicalReserve = parametersPresent.TechnologicalReserve,
                    RecommendationsArguments = parametersPresent.RecommendationsArguments
                };
            using FileStream fs = new(parametersDocPath, FileMode.Create);
            JsonSerializerOptions options = new()
            {
                IncludeFields = true
            };
            JsonSerializer.Serialize(fs, parameters, options);
        }

        /// <summary>
        /// Десериализация настраеваемых параметров расчёта конфигураций СКС
        /// </summary>
        /// <param name="parametersDocPath"></param>
        /// <returns></returns>
        public static SCSCalcParameters ParametersDeserializer(string parametersDocPath)
        {
            (bool? IsStrictСomplianceWithTheStandart,
                bool? IsAnArbitraryNumberOfPorts,
                bool? IsTechnologicalReserveAvailability,
                bool? IsRecommendationsAvailability,
                double TechnologicalReserve,
                RecommendationsArguments RecommendationsArguments) parameters;
            SCSCalcParameters parametersPresent = new();
            using FileStream fs = new(parametersDocPath, FileMode.Open);
            JsonSerializerOptions options = new()
            {
                IncludeFields = true
            };
            parameters = JsonSerializer.Deserialize<(bool?, bool?, bool?, bool?, double, RecommendationsArguments)>(fs, options);
            parametersPresent.IsStrictСomplianceWithTheStandart = parameters.IsStrictСomplianceWithTheStandart;
            parametersPresent.IsAnArbitraryNumberOfPorts = parameters.IsAnArbitraryNumberOfPorts;
            parametersPresent.IsTechnologicalReserveAvailability = parameters.IsTechnologicalReserveAvailability;
            parametersPresent.TechnologicalReserve = parameters.TechnologicalReserve;
            if (Equals(parameters.IsRecommendationsAvailability, true))
            {
                parametersPresent.IsRecommendationsAvailability = true;
                parametersPresent.RecommendationsArguments.IsolationType = parameters.RecommendationsArguments.IsolationType;
                parametersPresent.RecommendationsArguments.IsolationMaterial = parameters.RecommendationsArguments.IsolationMaterial;
                parametersPresent.RecommendationsArguments.ConnectionInterfaces = parameters.RecommendationsArguments.ConnectionInterfaces;
                parametersPresent.RecommendationsArguments.ShieldedType = parameters.RecommendationsArguments.ShieldedType;
            }
            else
            {
                parametersPresent.IsRecommendationsAvailability = false;
            }
            return parametersPresent;
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