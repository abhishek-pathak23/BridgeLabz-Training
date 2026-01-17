using System;
namespace FitnessController;

public class StepManager : IStepTracker
{
    private StepRecord[] records;
    private int totalUsers;

    public StepManager()
    {
        records = new StepRecord[20];
        totalUsers = 0;

        // Default users
        records[totalUsers++] = new StepRecord("Amit", 6500);
        records[totalUsers++] = new StepRecord("Riya", 8200);
        records[totalUsers++] = new StepRecord("Karan", 7400);
        records[totalUsers++] = new StepRecord("Sneha", 9000);
        records[totalUsers++] = new StepRecord("Vikram", 5000);
    }

    public void RegisterUser(string username, int steps)
    {
        if (totalUsers >= 20)
        {
            Console.WriteLine("Maximum users reached");
            return;
        }

        records[totalUsers++] = new StepRecord(username, steps);
    }

    public void ChangeSteps(int index, int steps)
    {
        if (index < 0 || index >= totalUsers)
        {
            Console.WriteLine("Invalid user position");
            return;
        }

        records[index].UpdateSteps(steps);
    }

    public void ShowRanking()
    {
        SortDescending();

        Console.WriteLine("\n--- Step Leaderboard ---");
        for (int i = 0; i < totalUsers; i++)
        {
            Console.WriteLine((i + 1) + ". " + records[i]);
        }
    }

    private void SortDescending()
    {
        for (int i = 0; i < totalUsers - 1; i++)
        {
            for (int j = 0; j < totalUsers - i - 1; j++)
            {
                if (records[j].GetStepCount() < records[j + 1].GetStepCount())
                {
                    StepRecord temp = records[j];
                    records[j] = records[j + 1];
                    records[j + 1] = temp;
                }
            }
        }
    }
}