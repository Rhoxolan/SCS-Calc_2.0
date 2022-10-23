﻿using System.Text.Json;

namespace SCSCalc.Parameters.WindowsDesktop
{
    //Реализация класса содержит методы для сериализации данных настраиваемых параметров вводимых значений конфигураций СКС.

    /// <summary>
    /// Класс, предоставляющий для других классов приложения доступ к настраиваемым параметрам вводимых значений конфигураций СКС.
    /// </summary>
    public class SCSCalcParameters : SCSCalcParametersBase
    {
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
            if(Equals(parameters.IsTechnologicalReserveAvailability, true))
            {
                parametersPresent.IsTechnologicalReserveAvailability = true;
                parametersPresent.TechnologicalReserve = parameters.TechnologicalReserve;
            }
            else
            {
                parametersPresent.IsTechnologicalReserveAvailability = false;
            }
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
    }
}