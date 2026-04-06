using System;
namespace FitnessController;

interface IStepTracker
{
    void RegisterUser(string username, int steps);
    void ChangeSteps(int index, int steps);
    void ShowRanking();
}