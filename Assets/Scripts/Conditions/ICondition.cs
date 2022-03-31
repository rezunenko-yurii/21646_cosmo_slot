using System;
using Conditions.Models;

namespace Core.Conditions.Watchers
{
    public interface ICondition
    {
        event Action<ConditionModel> Fulfilled;
        event Action ValueChanged;
        
        ConditionModel Model { get; }
        bool IsFulFilled();
    }
}