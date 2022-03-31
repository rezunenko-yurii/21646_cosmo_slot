using System;

namespace Core.Conditions
{
    public interface INumberConditionModel<out T> : IConditionModel
    {
        T Amount { get; }
    }
}