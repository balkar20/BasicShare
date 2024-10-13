namespace ParallelProcessing.Models;

public struct TimeFrame
{

    public State TimePerriodState { get; private set; }
    public RelativeTime RelativeTimePeriod { get; private set; }
    public int UnitsOfTime { get; private set; }

    public DateTime? StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }

    public TimeFrame(RelativeTime relativeTime, int unitsOfTime)
    {
        TimePerriodState = State.Absolute;
        RelativeTimePeriod = relativeTime;
        UnitsOfTime = unitsOfTime;
    }

    public TimeFrame(DateTime startTime, DateTime endTime)
    {
        TimePerriodState = State.Relative;
        StartTime = startTime;
        EndTime = endTime;
    }


    public enum State
    {
        None,
        Absolute,
        Relative
    }

    public enum RelativeTime
    {
        None,
        Hours,
        Days,
        Weeks,
        Months,
        Year
    }

}