using System;
using Conditions.Models;
using Core.Conditions;
using Core.Conditions.Watchers;

namespace Conditions
{
    public class Condition : ICondition
    {
        public event Action<ConditionModel> Fulfilled;
        public event Action ValueChanged;
        public ConditionModel Model { get; }

        public Condition(ConditionModel condition)
        {
            Model = condition;
        }
        
        public virtual bool IsFulFilled()
        {
            throw new NotImplementedException();
        }
        
        internal virtual void OnFulfilled()
        {
            Model.IsFulfilled = true;
            Fulfilled?.Invoke(Model);
        }

        internal virtual void OnValueChanged()
        {
            ValueChanged?.Invoke();
        }

        public void Reset()
        {
            throw new Exception();
            Model.CurrentAmount = 0;
            Model.IsFulfilled = false;
            OnValueChanged();
        }
    }
}