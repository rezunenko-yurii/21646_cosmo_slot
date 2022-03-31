namespace Core.Conditions
{
    public interface IConditions
    {
        bool IsConditionFulfilled(int level, int amount);
        IntRangeConditionModel GetCondition(int level);
    }
}