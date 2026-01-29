using System.Collections.Generic;

public class CreatorStats
{
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }

    // Shared storage
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
}
