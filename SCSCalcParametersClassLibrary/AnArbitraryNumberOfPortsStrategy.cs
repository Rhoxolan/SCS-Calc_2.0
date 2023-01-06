using static SCSCalc.Parameters.Properties.Resources;

namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class

    /// <summary>
    /// Class for determination of allowable ports count input value at allowable arbitrary count
    /// </summary>
    internal class AnArbitraryNumberOfPortsStrategy : IAnArbitraryNumberOfPortsStrategy
    {
        /// <summary>
        /// Determines allowable ports count input value at allowable arbitrary count
        /// </summary>
        public (decimal Min, decimal Max) NumberOfPortsDiapason
        {
            get
            {
                decimal min = Convert.ToDecimal(AnArbitraryNumberOfPorts_NumberOfPortsDiapason_Min);
                decimal max = Convert.ToDecimal(AnArbitraryNumberOfPorts_NumberOfPortsDiapason_Max);
                return (min, max);
            }
        }
    }
}
