namespace SCSCalc.Parameters
{
    public enum ConnectionInterfaceStandard
    {
        TenBASE_T = 1,
        FastEthernet = 2,
        GigabitBASE_T = 3,
        GigabitBASE_TX = 4,
        TwoPointFiveGBASE_T = 5,
        FiveGBASE_T = 6,
        TenGE = 7
    }

    internal interface IRecommendations
    {
        string RecommendationOutdoorCables { get; }
        string RecommendationLSZHCables { get; }
        string RecommendationFTPCable { get; }
        string RecommendationCableStandart { get; }
    }

    //internal class RecommendationsAvailability : IRecommendations
    //{

    //}

    internal class NonRecommendations : IRecommendations
    {
        public string RecommendationOutdoorCables
        {
            get
            {
                return Properties.Resources.NonRecommendations_RecommendationOutdoorCables;
            }
        }

        public string RecommendationLSZHCables
        {
            get
            {
                return Properties.Resources.NonRecommendations_RecommendationLSZHCables;
            }
        }

        public string RecommendationFTPCable
        {
            get
            {
                return Properties.Resources.NonRecommendations_RecommendationFTPCable;
            }
        }

        public string RecommendationCableStandart => throw new NotImplementedException();
    }

    internal class RecommendationLocator
    {

        public void SetRecommendationIndoorCable()
        {

        }

        public void SetRecommendationOutdoorCable()
        {

        }

        public void SetRecommendationNonLSZHCable()
        {

        }

        public void SetRecommendationLSZHCable()
        {

        }
    }
}
