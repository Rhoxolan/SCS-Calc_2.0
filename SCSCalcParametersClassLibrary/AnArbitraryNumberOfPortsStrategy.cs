using static SCSCalc.Parameters.Properties.Resources;
using static System.Convert;

namespace SCSCalc.Parameters
{
    //Encapsulates in DiapasonContext class

    /// <summary>
    /// Class for determination of allowable ports count input value at allowable arbitrary count
    /// </summary>
    internal class AnArbitraryNumberOfPortsStrategy : IAnArbitraryNumberOfPortsStrategy
    {
        private (decimal Min, decimal Max) numberOfPortsDiapason;

        public AnArbitraryNumberOfPortsStrategy()
        {
            numberOfPortsDiapason = (ToDecimal(AnArbitraryNumberOfPorts_NumberOfPortsDiapason_Min),
                ToDecimal(AnArbitraryNumberOfPorts_NumberOfPortsDiapason_Max));
        }

        /// <summary>
        /// Determines allowable ports count input value at allowable arbitrary count
        /// </summary>
        public (decimal Min, decimal Max) NumberOfPortsDiapason
        {
            get => numberOfPortsDiapason;
        }
    }
}
