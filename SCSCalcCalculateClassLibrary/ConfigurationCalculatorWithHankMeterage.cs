using SCSCalc.Parameters;
using System.Text;

namespace SCSCalc.Calculate
{
    /// <summary>
    /// Presents the calculate method of structured cabling configuration with cable hank meterage
    /// </summary>
    internal class ConfigurationCalculatorWithHankMeterage : IConfigurationCalculatorStrategy
    {
        /// <summary>
        /// Calculate method of structured cabling configuration with cable hank meterage
        /// </summary>
        /// <exception cref="SCSCalcException"></exception>
        public Configuration Calculate(SCSCalcParameters parameters, double minPermanentLink, double maxPermanentLink, int numberOfWorkplaces, int numberOfPorts, double? cableHankMeterage)
        {
            if (cableHankMeterage is null)
            {
                throw new SCSCalcException("Ошибка расчёта конфигурации! Значение метража кабеля в 1-й кабельной катушке не определено.");
            }
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
                if (!string.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationIsolationType))
                {
                    recommendationsBuilder.AppendLine($"Рекомендуемый тип изоляции кабеля: {parameters.CableSelectionRecommendations.RecommendationIsolationType}");
                }
                if (!string.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationIsolationMaterial))
                {
                    recommendationsBuilder.AppendLine($"Рекомендуемый материал изоляции кабеля: {parameters.CableSelectionRecommendations.RecommendationIsolationMaterial}");
                }
                if (!string.IsNullOrEmpty(parameters.CableSelectionRecommendations.RecommendationCableStandart))
                {
                    recommendationsBuilder.AppendLine($"Рекомендуемая категория кабеля: {parameters.CableSelectionRecommendations.RecommendationCableStandart}");
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
                СableQuantity = cableQuantity,
                CableHankMeterage = cableHankMeterage,
                HankQuantity = hankQuantity,
                TotalСableQuantity = totalСableQuantity,
                Recommendations = recommendations
            };
        }
    }
}
