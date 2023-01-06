using static SCSCalc.Parameters.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class

    /// <summary>
    /// Class for determination of allowable ports count input value at ISO/IEC 11801 standard compliance
    /// </summary>
    internal class NotAnArbitraryNumberOfPortsStrategy : IAnArbitraryNumberOfPortsStrategy
    {
        /// <summary>
        /// Determines of allowable ports count input value at ISO/IEC 11801 standard compliance
        /// </summary>
        public (decimal Min, decimal Max) NumberOfPortsDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(NotAnArbitraryNumberOfPorts_NumberOfPortsDiapason_Min);
                decimal max = Convert.ToDecimal(NotAnArbitraryNumberOfPorts_NumberOfPortsDiapason_Max);
                return (min, max);
            }
        }
    }
}
