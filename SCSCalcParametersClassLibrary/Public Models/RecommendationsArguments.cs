namespace SCSCalc.Parameters
{
    /// <summary>
    /// Presents arguments for get cable selection
    /// </summary>
    public class RecommendationsArguments
    {
        /// <summary>
        /// Insluation type of recommended cable
        /// </summary>
        public IsolationType IsolationType { get; set; }

        /// <summary>
        /// Incluation material of recommended cable
        /// </summary>
        public IsolationMaterial IsolationMaterial { get; set; }

        /// <summary>
        /// Shielding type of recommended cable
        /// </summary>
        public ShieldedType ShieldedType { get; set; }

        /// <summary>
        /// List of planned connection interfaces
        /// </summary>
        public List<ConnectionInterfaceStandard> ConnectionInterfaces { get; set; } = new() { ConnectionInterfaceStandard.None };
    }
}
