using System.Text.Json;

namespace SCSCalc
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
            (bool IsStrictСomplianceWithTheStandart, bool IsAnArbitraryNumberOfPorts, bool IsTechnologicalReserveAvailability,
                bool IsRecommendationsAvailability, double TechnologicalReserve, IsolationType IsolationType, IsolationMaterial IsolationMaterial,
                ShieldedType ShieldedType, List<ConnectionInterfaceStandard> ConnectionInterfaces) parameters = new()
                {
                    IsStrictСomplianceWithTheStandart = parametersPresent.IsStrictСomplianceWithTheStandart,
                    IsAnArbitraryNumberOfPorts = parametersPresent.IsAnArbitraryNumberOfPorts,
                    IsTechnologicalReserveAvailability = parametersPresent.IsTechnologicalReserveAvailability,
                    IsRecommendationsAvailability = parametersPresent.IsRecommendationsAvailability,
                    TechnologicalReserve = parametersPresent.TechnologicalReserve,
                    IsolationType = parametersPresent.IsolationType,
                    IsolationMaterial = parametersPresent.IsolationMaterial,
                    ShieldedType = parametersPresent.ShieldedType,
                    ConnectionInterfaces = parametersPresent.ConnectionInterfaces
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
            (bool IsStrictСomplianceWithTheStandart, bool IsAnArbitraryNumberOfPorts, bool IsTechnologicalReserveAvailability,
                bool IsRecommendationsAvailability, double TechnologicalReserve, IsolationType IsolationType, IsolationMaterial IsolationMaterial,
                ShieldedType ShieldedType, List<ConnectionInterfaceStandard> ConnectionInterfaces) parameters;

            SCSCalcParameters parametersPresent = new();

            using FileStream fs = new(parametersDocPath, FileMode.Open);
            JsonSerializerOptions options = new()
            {
                IncludeFields = true
            };
            parameters = JsonSerializer.Deserialize<(bool, bool, bool, bool, double,
                IsolationType, IsolationMaterial, ShieldedType, List<ConnectionInterfaceStandard>)>(fs, options);

            if (parameters.IsStrictСomplianceWithTheStandart)
            {
                parametersPresent.SetStrictСomplianceWithTheStandart();
            }
            else
            {
                parametersPresent.SetNonStrictСomplianceWithTheStandart();
            }

            if (parameters.IsAnArbitraryNumberOfPorts)
            {
                parametersPresent.SetAnArbitraryNumberOfPorts();
            }
            else
            {
                parametersPresent.SetNotAnArbitraryNumberOfPorts();
            }

            if (parameters.IsTechnologicalReserveAvailability)
            {
                parametersPresent.SetTechnologicalReserveAvailability();
                parametersPresent.TechnologicalReserve = parameters.TechnologicalReserve;
            }
            else
            {
                parametersPresent.SetNonTechnologicalReserve();
            }

            if(parameters.IsRecommendationsAvailability)
            {
                parametersPresent.SetRecommendationsAvailability();
                parametersPresent.IsolationType = parameters.IsolationType;
                parametersPresent.IsolationMaterial = parameters.IsolationMaterial;
                parametersPresent.ShieldedType = parameters.ShieldedType;
                parametersPresent.ConnectionInterfaces = parameters.ConnectionInterfaces;
            }
            else
            {
                parametersPresent.SetNonRecommendations();
            }

            return parametersPresent;
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
        /// Рекомендации по подбору кабеля
        /// </summary>
        public (string RecommendationIsolationType, string RecommendationIsolationMaterial, string RecommendationShieldedType, string RecommendationCableStandart) Recommendations
        {
            get
            {
                return (recommendationLocator.RecommendationIsolationType, recommendationLocator.RecommendationIsolationMaterial, recommendationLocator.RecommendationShieldedType,
                    recommendationLocator.RecommendationCableStandart);
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
        /// Тип изоляции рекомендуемого кабеля
        /// </summary>
        public IsolationType IsolationType
        {
            get => recommendationLocator.IsolationType;
            set => recommendationLocator.IsolationType = value;
        }

        /// <summary>
        /// Материал изоляции рекомендуемого кабеля
        /// </summary>
        public IsolationMaterial IsolationMaterial
        {
            get => recommendationLocator.IsolationMaterial;
            set => recommendationLocator.IsolationMaterial = value;
        }

        /// <summary>
        /// Тип экранизации рекомендуемого кабеля
        /// </summary>
        public ShieldedType ShieldedType
        {
            get => recommendationLocator.ShieldedType;
            set => recommendationLocator.ShieldedType = value;
        }

        /// <summary>
        /// Cписок планируемых интерфейсов подключений
        /// </summary>
        public List<ConnectionInterfaceStandard> ConnectionInterfaces
        {
            get => recommendationLocator.ConnectionInterfaces;
            set => recommendationLocator.ConnectionInterfaces = value;
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