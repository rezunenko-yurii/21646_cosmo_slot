namespace Multipliers
{
    public abstract class TimeBasedMultiplier : Multiplier, ITimeBasedMultiplier
    {
        public float Hours { get; protected set; }
    }
}