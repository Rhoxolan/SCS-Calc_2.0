namespace SCSCalc.Parameters
{
    /// <summary>
    /// //Класс, инкапсулирующий объекты для работы со значениями расчета конфигураций СКС
    /// </summary>
    internal class ValueContext
    {
        private ITechnologicalReserveStrategy? technologicalReserveStrategy;

        public ValueContext()
        {
            IsTechnologicalReserveAvailability = null;
            technologicalReserveStrategy = null;
        }

        /// <summary>
        /// Значение коэффициента технологического запаса
        /// </summary>
        public double TechnologicalReserve
        {
            get
            {
                if (technologicalReserveStrategy != null)
                {
                    return technologicalReserveStrategy.TechnologicalReserve;
                }
                throw new SCSCalcException("Значение необходимости учёта технологического запаса не инициализировано. Пожалуйста, проверьте настройки.");
            }
            set
            {
                if (technologicalReserveStrategy != null)
                {
                    technologicalReserveStrategy.TechnologicalReserve = value;
                }
                else
                {
                    throw new SCSCalcException("Значение необходимости учёта технологического запаса не инициализировано. Пожалуйста, проверьте настройки.");
                }
            }
        }

        /// <summary>
        /// Учитывается или нет коэффициент технологического запаса
        /// </summary>
        public bool? IsTechnologicalReserveAvailability
        {
            get
            {
                if (technologicalReserveStrategy is TechnologicalReserveAvailabilityStrategy)
                {
                    return true;
                }
                if (technologicalReserveStrategy is NonTechnologicalReserveStrategy)
                {
                    return false;
                }
                throw new SCSCalcException("Значение необходимости учёта технологического запаса не инициализировано. Пожалуйста, проверьте настройки.");
            }
            set
            {
                if (Equals(value, true))
                {
                    technologicalReserveStrategy = new TechnologicalReserveAvailabilityStrategy();
                }
                else
                {
                    technologicalReserveStrategy = new NonTechnologicalReserveStrategy();
                }
            }
        }
    }
}
