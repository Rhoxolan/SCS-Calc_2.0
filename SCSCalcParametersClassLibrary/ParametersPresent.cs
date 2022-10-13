namespace SCSCalc.Parameters
{
    /// <summary>
    /// Класс, предоставляющий для других классов приложения доступ к настраиваемым параметрам вводимых значений конфигураций СКС.
    /// </summary>
    public class ParametersPresent
    {
        private DiapasonLocator diapasonLocator;
        private ValueLocator valueLocator;

        public ParametersPresent()
        {
            diapasonLocator = new();
            valueLocator = new();
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
        /// Значение коэффициента технологического запаса
        /// </summary>
        public double TechnologicalReserve
        {
            get => valueLocator.TechnologicalReserve;
            set => valueLocator.TechnologicalReserve = value;
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