using SCSCalc.Parameters;
using System.Text;

namespace SCSCalc
{
    /// <summary>
    /// Класс, описывающий метод расчёта конфигурации СКС без учета метража кабеля в 1-й кабельной катушке
    /// </summary>
    internal class ConfigurationCalculatorWithoutHankMeterage : IConfigurationCalculator
    {
        /// <summary>
        /// Расчёт конфигурации СКС без учета метража кабеля в 1-й кабельной катушке
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="minPermanentLink"></param>
        /// <param name="maxPermanentLink"></param>
        /// <param name="numberOfWorkplaces"></param>
        /// <param name="numberOfPorts"></param>
        /// <param name="cableHankMeterage"></param>
        /// <returns></returns>
        public Configuration Calculate(SCSCalcParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces, int numberOfPorts, double? cableHankMeterage)
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
                    recommendationsBuilder.AppendLine($"Рекомендуемый тип экранизации кабеля: {parameters.CableSelectionRecommendations.RecommendationShieldedType}");
                }
                recommendations = recommendationsBuilder.ToString();
            }
            return new Configuration
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
