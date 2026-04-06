using System;
namespace FitnessController;

public class StepRecord
{
    private string userName;
    private int stepTotal;

    public StepRecord(string userName, int stepTotal)
    {
        this.userName = userName;
        this.stepTotal = stepTotal;
    }

    public string GetUserName()
    {
        return userName;
    }

    public void SetUserName(string userName)
    {
        this.userName = userName;
    }

    public int GetStepCount()
    {
        return stepTotal;
    }

    public void UpdateSteps(int steps)
    {
        stepTotal = steps;
    }

    public override string ToString()
    {
        return "User: " + userName + " | Steps: " + stepTotal;
    }
}