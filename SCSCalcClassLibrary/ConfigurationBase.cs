﻿namespace SCSCalc
{
    /// <summary>
    /// Запись конфигурации СКС
    /// </summary>
    public abstract record ConfigurationBase
    {
        /// <summary>
        /// Id текущей записи конфигурации СКС
        /// </summary>
        protected ushort Id { get; init; }

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
        /// Возвращяет свободный id для конфигурации
        /// </summary>
        /// <param name="configurations"></param>
        /// <returns></returns>
        /// <exception cref="SCSCalcException"></exception>
        protected static ushort GetId(ICollection<ConfigurationBase> configurations)
        {
            for(ushort i = 0; i < ushort.MaxValue; i++)
            {
                if(!configurations.Select(x => x.Id).Contains(i))
                {
                    return i;
                }
            }
            throw new SCSCalcException("Превышен допустимый диапазон количества конфигураций СКС. Пожалуйста, удалите ненужные записи конфигурации.");
        }
    }
}