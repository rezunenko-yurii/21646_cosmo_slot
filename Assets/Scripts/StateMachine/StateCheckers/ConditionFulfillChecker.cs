using Conditions;
using Conditions.Models;
using UnityEngine;
using Zenject;

namespace StateMachine
{
    public class ConditionFulfillChecker : DualStateChecker
    {
        [SerializeField] protected ConditionModel model;
        [Inject] private ConditionsImp.Conditions conditions;
        private Condition condition;
        
        protected override void Initialize()
        {
            base.Initialize();
            condition = conditions.All[model];
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            
            if (model.IsFulfilled)
            {
                SetAllActive();
            }
            else
            {
                SetAllInactive();
                condition.Fulfilled += OnFulfilled;
            }
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
            
            if (condition != null)
            {
                condition.Fulfilled -= OnFulfilled; 
            }
        }

        private void OnFulfilled(ConditionModel model)
        {
            SetAllActive();
        }
    }
}