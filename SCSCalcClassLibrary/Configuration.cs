using SCSCalc.Parameters;
using System.Text;

namespace SCSCalc
{
    /// <summary>
    /// Запись конфигурации СКС
    /// </summary>
    public record Configuration
    {
        /// <summary>
        /// Id текущей записи конфигурации СКС
        /// </summary>
        public ushort Id { get; init; }

        /// <summary>
        /// Дата записи конфигурации СКС
        /// </summary>
        public DateTime RecordTime { get; init; }

        /// <summary>
        /// Значение минимальной длины постоянного линка в записи конфигурации СКС
        /// </summary>
        public double MinPermanentLink { get; init; }

        /// <summary>
        /// Значение максимальной длины постоянного линка в записи конфигурации СКС
        /// </summary>
        public double MaxPermanentLink { get; init; }

        /// <summary>
        /// Значение средней длины постоянного линка в записи конфигурации СКС
        /// </summary>
        public double AveragePermanentLink { get; init; }

        /// <summary>
        /// Значение количества рабочих мест в записи конфигурации СКС
        /// </summary>
        public int NumberOfWorkplaces { get; init; }

        /// <summary>
        /// Значение количества портов на 1 рабочее место в записи конфигурации СКС
        /// </summary>
        public int NumberOfPorts { get; init; }

        /// <summary>
        /// Значение необходимого количества кабеля в записи конфигурации СКС.
        /// Присутствует, если конфигурация СКС расчитывалась с учётом количества кабеля в 1-й бухте.
        /// </summary>
        public double? СableQuantity { get; init; } = null;

        /// <summary>
        /// Значение метража кабеля в 1-й кабельной катушке (бухте) в записи конфигурации СКС.
        /// Присутствует, если конфигурация СКС расчитывалась с учётом количества кабеля в 1-й бухте.
        /// </summary>
        public double? CableHankMeterage { get; init; } = null;

        /// <summary>
        /// Значение количества кабельных катушек в записи конфигурации СКС.
        /// Присутствует, если конфигурация СКС расчитывалась с учётом количества кабеля в 1-й бухте.
        /// </summary>
        public int? HankQuantity { get; init; } = null;

        /// <summary>
        /// Значение общего количества необходимого метража кабеля в записи конфигурации СКС.
        /// </summary>
        public double TotalСableQuantity { get; init; }

        /// <summary>
        /// Рекомендации по побдору кабеля в в записи конфигурации СКС.
        /// Присутствует, если указана необходимость получения соответствующих рекомендаций.
        /// </summary>
        public string? Recommendations { get; init; }

        /// <summary>
        /// Расчёт конфигурации СКС
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="minPermanentLink"></param>
        /// <param name="maxPermanentLink"></param>
        /// <param name="numberOfWorkplaces"></param>
        /// <param name="numberOfPorts"></param>
        /// <param name="cableHankMeterage"></param>
        /// <returns></returns>
        /// <exception cref="SCSCalcException"></exception>
        public static Configuration Calculate(SCSCalcParametersBase parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces,
            int numberOfPorts, double? cableHankMeterage)
        {
            if (cableHankMeterage != null)
            {
                double averagePermanentLink = (minPermanentLink + maxPermanentLink) / 2 * parameters.TechnologicalReserve;
                if (averagePermanentLink > cableHankMeterage)
                {
                    throw new SCSCalcException("Расчет провести невозможно! Значение средней длины постояного линка превышает значение метража кабеля в бухте.");
                }
                double? cableQuantity = averagePermanentLink * numberOfWorkplaces * numberOfPorts;
                int? hankQuantity = (int)Math.Ceiling(numberOfWorkplaces * numberOfPorts / Math.Floor((double)(cableHankMeterage / averagePermanentLink)));
                double totalСableQuantity = (double)(hankQuantity * cableHankMeterage);
                string? recommendations = null;
                if (Equals(parameters.IsRecommendationsAvailability, true))
                {
                    StringBuilder recommendationsBuilder = new();
                    if (!String.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationIsolationType))
                    {
                        recommendationsBuilder.AppendLine($"Рекомендуемый тип изоляции кабеля: {parameters.CableSelectionRecommendations.RecommendationIsolationType}");
                    }
                    if (!String.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationIsolationMaterial))
                    {
                        recommendationsBuilder.AppendLine($"Рекомендуемый материал изоляции кабеля: {parameters.CableSelectionRecommendations.RecommendationIsolationMaterial}");
                    }
                    if (!String.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationCableStandart))
                    {
                        recommendationsBuilder.AppendLine($"Рекомендуемая категория кабеля: {parameters.CableSelectionRecommendations.RecommendationCableStandart}");
                    }
                    if (!String.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationShieldedType))
                    {
                        recommendationsBuilder.AppendLine($"Рекомендуемый тип экранизации кабеля: {parameters.CableSelectionRecommendations.RecommendationCableStandart}");
                    }
                    recommendations = recommendationsBuilder.ToString();
                }
                return new Configuration()
                {
                    RecordTime = DateTime.Now,
                    MinPermanentLink = minPermanentLink,
                    MaxPermanentLink = maxPermanentLink,
                    AveragePermanentLink = averagePermanentLink,
                    NumberOfWorkplaces = numberOfWorkplaces,
                    NumberOfPorts = numberOfPorts,
                    СableQuantity = cableQuantity,
                    CableHankMeterage = cableHankMeterage,
                    HankQuantity = hankQuantity,
                    TotalСableQuantity = totalСableQuantity,
                    Recommendations = recommendations
                };
            }
            else
            {
                double averagePermanentLink = (minPermanentLink + maxPermanentLink) / 2 * parameters.TechnologicalReserve;
                double totalСableQuantity = averagePermanentLink * numberOfWorkplaces * numberOfPorts;
                string? recommendations = null;
                if (Equals(parameters.IsRecommendationsAvailability, true))
                {
                    StringBuilder recommendationsBuilder = new();
                    if (!String.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationIsolationType))
                    {
                        recommendationsBuilder.AppendLine($"Рекомендуемый тип изоляции кабеля: {parameters.CableSelectionRecommendations.RecommendationIsolationType}");
                    }
                    if (!String.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationIsolationMaterial))
                    {
                        recommendationsBuilder.AppendLine($"Рекомендуемый материал изоляции кабеля: {parameters.CableSelectionRecommendations.RecommendationIsolationMaterial}");
                    }
                    if (!String.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationCableStandart))
                    {
                        recommendationsBuilder.AppendLine($"Рекомендуемая категория кабеля: {parameters.CableSelectionRecommendations.RecommendationCableStandart}");
                    }
                    if (!String.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationShieldedType))
                    {
                        recommendationsBuilder.AppendLine($"Рекомендуемый тип экранизации кабеля: {parameters.CableSelectionRecommendations.RecommendationCableStandart}");
                    }
                    recommendations = recommendationsBuilder.ToString();
                }
                return new Configuration()
                {
                    RecordTime = DateTime.Now,
                    MinPermanentLink = minPermanentLink,
                    MaxPermanentLink = maxPermanentLink,
                    AveragePermanentLink = averagePermanentLink,
                    NumberOfWorkplaces = numberOfWorkplaces,
                    NumberOfPorts = numberOfPorts,
                    TotalСableQuantity = totalСableQuantity,
                    Recommendations = recommendations
                };
            }
        }
    }
}