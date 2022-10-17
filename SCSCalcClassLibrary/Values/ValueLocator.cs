namespace SCSCalc
{
    //Класс, инкапсулирующий объекты для работы со значениями расчета конфигкраций СКС.

    /// <summary>
    /// //Класс, инкапсулирующий объекты для работы со значениями расчета конфигураций СКС
    /// </summary>
    internal class ValueLocator
    {
        private ITechnologicalReserve? technologicalReserve;

        public ValueLocator()
        {
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
        /// Устанавливает учёт технологического запаса
        /// </summary>
        public void SetTechnologicalReserveAvailability()
        {
            technologicalReserve = new TechnologicalReserveAvailability();
        }

        /// <summary>
        /// Расчёт без учёта технологического запаса
        /// </summary>
        public void SetNonTechnologicalReserve()
        {
            technologicalReserve = new NonTechnologicalReserve();
        }

        /// <summary>
        /// Учитывается или нет коэффициент технологического запаса
        /// </summary>
        public bool IsTechnologicalReserveAvailability
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
        }
    }
}
