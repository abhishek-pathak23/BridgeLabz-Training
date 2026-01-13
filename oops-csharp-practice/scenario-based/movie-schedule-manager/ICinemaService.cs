namespace BridgeLabzTraining.oops_csharp_practice.scenario_based.cinema_time
{
    // Interface defines allowed cinema operations
    public interface ICinemaService
    {
        void AddMovie(string title, string time);
        void SearchMovie(string keyword);
        void DisplayAllMovies();
        void PrintReport();
    }
}
