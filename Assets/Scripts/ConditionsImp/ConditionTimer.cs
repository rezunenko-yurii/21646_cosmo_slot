using Conditions;
using Conditions.Models;
using Core.Conditions;
using Core.Timers;
using Dates;

namespace ConditionsImp
{
    public class ConditionTimer : MemoryTimer
    {
        private ConditionModel _model;
        private Condition _condition;
        
        public ConditionTimer(NextDateKeeper nextDateKeeper, ConditionModel model, Condition condition) : base(nextDateKeeper)
        {
            _model = model;
            _condition = condition;

            _condition.ValueChanged += OnValueChanged;
            _condition.Fulfilled += OnFulfilled;

            if (CanUse)
            {
                _condition.Reset();
            }
        }

        private void OnFulfilled(ConditionModel model)
        {
            _condition.Fulfilled -= OnFulfilled;
            
            Stop();
            Keeper.Reset();
        }

        private void OnValueChanged()
        {
            if (CanUse)
            {
                var a = _model as ITimerRequest;
                Keeper.AddHoursFromNow(a.Hours);
                //keeper.AddMinutesFromNow(1);
            }
        }

        private bool CanUse => IsExpired && !_model.IsFulfilled && _model.CurrentAmount > 0;

        protected override void OnOver()
        {
           base.OnOver();
            if (!_model.IsFulfilled)
            {
                if (_model is ITimerRequest)
                {
                    _condition.Reset();
                }
            }
        }
    }
}