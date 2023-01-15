namespace SCSCalc.Parameters
{
    /// <summary>
    /// Class which encapsulates objects for work with structured cabling configuration calculation values
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
        /// Value of technological reserve coefficient
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
        /// Is technological reserve coefficient value availability enabled or disabled
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
