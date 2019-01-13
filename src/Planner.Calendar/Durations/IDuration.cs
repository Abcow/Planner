namespace Planner.Calendar
{
    public interface IDuration
    {
        bool IsPositive { get; }
        bool IsNegative { get; }
        bool IsZero { get; }
    }
}
