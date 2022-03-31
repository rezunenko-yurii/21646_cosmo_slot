using System;
using System.Collections.Generic;
using Core.Conditions;
using UnityEngine;

namespace Conditions
{
    [Serializable]
    [CreateAssetMenu(menuName = "Conditions/ Create Conditions List")]
    public class ConditionsStepper : ScriptableObject
    {
        [field: SerializeReference, SerializeReferenceButton] public List<IConditionModel> Items { get; private set; }

        public IConditionModel Condition(int value)
        {
            return Items[0];
            //return Items.First(condition => condition.ContainsValue(value));
        }
    }
}