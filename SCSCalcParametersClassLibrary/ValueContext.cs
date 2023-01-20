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
                throw new SCSCalcException("The need to consider of technological reserve coefficient value is not initialized. Please check the settings.");
            }
            set
            {
                if (technologicalReserveStrategy != null)
                {
                    technologicalReserveStrategy.TechnologicalReserve = value;
                }
                else
                {
                    throw new SCSCalcException("The need to consider of technological reserve coefficient value is not initialized. Please check the settings.");
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
                throw new SCSCalcException("The need to consider of technological reserve coefficient value is not initialized. Please check the settings.");
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
