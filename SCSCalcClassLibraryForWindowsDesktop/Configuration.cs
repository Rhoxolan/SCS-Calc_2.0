using SCSCalc.Parameters;
using System.Collections.ObjectModel;
using System.Text;

namespace SCSCalc.WindowsDesktop
{
    //Реализация записи содержит методы для расчёта конфигураций и загрузе/выгрузке БД конфигураций

    /// <summary>
    /// Запись конфигурации СКС
    /// </summary>
    public record Configuration : ConfigurationBase
    {
        /// <summary>
        /// Расчёт конфигурации СКС
        /// </summary>
        /// <param name="configurations"></param>
        /// <param name="parameters"></param>
        /// <param name="minPermanentLink"></param>
        /// <param name="maxPermanentLink"></param>
        /// <param name="numberOfWorkplaces"></param>
        /// <param name="numberOfPorts"></param>
        /// <param name="cableHankMeterage"></param>
        /// <returns></returns>
        /// <exception cref="SCSCalcException"></exception>
        public static Configuration Calculate(ICollection<Configuration> configurations, SCSCalcParametersBase parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces,
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
                    Id = GetId(new ObservableCollection<ConfigurationBase>(configurations)),
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
                    Id = GetId(new ObservableCollection<ConfigurationBase>(configurations)),
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
