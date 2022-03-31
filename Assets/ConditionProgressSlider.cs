using Conditions;
using Conditions.Models;
using Core.Conditions;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class ConditionProgressSlider : AdvancedSlider
{
    [SerializeField] private ConditionModel model;
    [Inject] private ConditionsImp.Conditions _conditions;
    private Condition _condition;

    protected override void Initialize()
    {
        base.Initialize();
        _condition = _conditions.All[model];
    }

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        ChangeSliderValue(model.CurrentAmount, model.TargetAmount);
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        
        if (!model.IsFulfilled)
        {
            _condition.ValueChanged += OnValueChanged;
        }
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        _condition.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged()
    {
        ChangeSliderValue(model.CurrentAmount, model.TargetAmount);
    }
}
