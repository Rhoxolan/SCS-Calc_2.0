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
        public uint Id { get; init; }

        /// <summary>
        /// Дата записи конфигурации СКС
        /// </summary>
        public required DateTime RecordTime { get; init; }

        /// <summary>
        /// Значение минимальной длины постоянного линка в записи конфигурации СКС
        /// </summary>
        public required double MinPermanentLink { get; init; }

        /// <summary>
        /// Значение максимальной длины постоянного линка в записи конфигурации СКС
        /// </summary>
        public required double MaxPermanentLink { get; init; }

        /// <summary>
        /// Значение средней длины постоянного линка в записи конфигурации СКС
        /// </summary>
        public required double AveragePermanentLink { get; init; }

        /// <summary>
        /// Значение количества рабочих мест в записи конфигурации СКС
        /// </summary>
        public required int NumberOfWorkplaces { get; init; }

        /// <summary>
        /// Значение количества портов на 1 рабочее место в записи конфигурации СКС
        /// </summary>
        public required int NumberOfPorts { get; init; }

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
        public required double TotalСableQuantity { get; init; }

        /// <summary>
        /// Рекомендации по побдору кабеля в в записи конфигурации СКС.
        /// Присутствует, если указана необходимость получения соответствующих рекомендаций.
        /// </summary>
        public string? Recommendations { get; init; }
    }
}