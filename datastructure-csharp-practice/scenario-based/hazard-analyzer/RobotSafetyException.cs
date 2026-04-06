using System;

namespace RobotHazardAnalyzer
{
    public class RobotSafetyException : Exception
    {
        public RobotSafetyException(string message)
            : base(message)
        {
        }
    }
}
