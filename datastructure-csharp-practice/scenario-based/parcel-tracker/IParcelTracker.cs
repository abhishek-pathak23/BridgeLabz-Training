namespace ParcelTracker.Interface
{
    public interface IParcelTracker
    {
        void AddStage(string stageName);
        void DisplayStages();
        void CheckParcelStatus();
    }
}
