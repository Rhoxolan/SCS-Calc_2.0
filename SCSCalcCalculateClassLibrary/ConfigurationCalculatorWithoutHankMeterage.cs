using SCSCalc.Parameters;
using System.Text;

namespace SCSCalc.Calculate
{
    /// <summary>
    /// Presents the calculate method of structured cabling configuration without cable hank meterage
    /// </summary>
    internal class ConfigurationCalculatorWithoutHankMeterage : IConfigurationCalculatorStrategy
    {
        /// <summary>
        /// Calculate method of structured cabling configuration without cable hank meterage
        /// </summary>
        public Configuration Calculate(SCSCalcParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces, int numberOfPorts, double? cableHankMeterage)
        {
            double averagePermanentLink = (minPermanentLink + maxPermanentLink) / 2 * parameters.TechnologicalReserve;
            double totalCableQuantity = averagePermanentLink * numberOfWorkplaces * numberOfPorts;
            string? recommendations = null;
            if (Equals(parameters.IsRecommendationsAvailability, true))
            {
                StringBuilder recommendationsBuilder = new();
                if (!string.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationIsolationType))
                {
                    recommendationsBuilder.AppendLine($"Рекомендуемый тип изоляции кабеля: {parameters.CableSelectionRecommendations.RecommendationIsolationType}");
                }
                if (!string.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationIsolationMaterial))
                {
                    recommendationsBuilder.AppendLine($"Рекомендуемый материал изоляции кабеля: {parameters.CableSelectionRecommendations.RecommendationIsolationMaterial}");
                }
                if (!string.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationCableStandard))
                {
                    recommendationsBuilder.AppendLine($"Рекомендуемая категория кабеля: {parameters.CableSelectionRecommendations.RecommendationCableStandard}");
                }
                if (!string.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationShieldedType))
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
                TotalCableQuantity = totalCableQuantity,
                Recommendations = recommendations
            };
        }
    }
}
