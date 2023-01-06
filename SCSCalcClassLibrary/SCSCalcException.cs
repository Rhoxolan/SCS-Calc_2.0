namespace SCSCalc
{
    // Exceptions in SCSCalc application logic. As example - overflow of permissible permanent link length.
    //
    // Exceptions should not be handled in the app!

    /// <summary>
    /// Exceptions in SCSCalc application logic
    /// </summary>
    public class SCSCalcException : Exception
    {
        public SCSCalcException()
        {
        }

        public SCSCalcException(string message)
            : base(message)
        {
        }

        public SCSCalcException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}