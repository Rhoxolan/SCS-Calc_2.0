namespace SCSCalc.Parameters
{
    /// <summary>
    /// //Класс, инкапсулирующий объекты для работы со значениями расчета конфигураций СКС
    /// </summary>
    internal class ValueLocator
    {
        private ITechnologicalReserve? technologicalReserve;

        public ValueLocator()
        {
            IsTechnologicalReserveAvailability = null;
            technologicalReserve = null;
        }

        /// <summary>
        /// Значение коэффициента технологического запаса
        /// </summary>
        public double TechnologicalReserve
        {
            get
            {
                if (technologicalReserve != null)
                {
                    return technologicalReserve.TechnologicalReserve;
                }
                throw new SCSCalcException("Значение необходимости учёта технологического запаса не инициализировано. Пожалуйста, проверьте настройки.");
            }
            set
            {
                if (technologicalReserve != null)
                {
                    technologicalReserve.TechnologicalReserve = value;
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
                if (technologicalReserve is TechnologicalReserveAvailability)
                {
                    return true;
                }
                if (technologicalReserve is NonTechnologicalReserve)
                {
                    return false;
                }
                throw new SCSCalcException("Значение необходимости учёта технологического запаса не инициализировано. Пожалуйста, проверьте настройки.");
            }
            set
            {
                if (Equals(value, true))
                {
                    technologicalReserve = new TechnologicalReserveAvailability();
                }
                else
                {
                    technologicalReserve = new NonTechnologicalReserve();
                }
            }
        }
    }
}
