namespace SCSCalc
{
    /// <summary>
    /// Класс, представщяющий аргументы для получения рекомендаций по побдору кабеля
    /// </summary>
    public class RecommendationsArguments
    {
        /// <summary>
        /// Тип изоляции рекомендуемого кабеля
        /// </summary>
        public IsolationType IsolationType { get; set; }

        /// <summary>
        /// Материал изоляции рекомендуемого кабеля
        /// </summary>
        public IsolationMaterial IsolationMaterial { get; set; }

        /// <summary>
        /// Тип экранизации рекомендуемого кабеля
        /// </summary>
        public ShieldedType ShieldedType { get; set; }

        /// <summary>
        /// Список планируемых интерфейсов подключений
        /// </summary>
        public List<ConnectionInterfaceStandard> ConnectionInterfaces { get; set; } = new() { ConnectionInterfaceStandard.None };
    }
}
