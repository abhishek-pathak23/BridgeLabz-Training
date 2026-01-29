using System.Collections.Generic;

public interface IStreamBuzzService
{
    void RegisterCreator(CreatorStats record);

    Dictionary<string, int> GetTopPostCounts(
        List<CreatorStats> records, double likeThreshold);

    double CalculateAverageLikes();
}
