using System;
using System.Linq;
using UnityEngine;

namespace Core.Conditions
{
    [Serializable]
    public class IntRangeConditionModel : IntConditionModel
    {
        [field: SerializeField] public int From { get; protected set; }
        [field: SerializeField] public int To { get; protected set; }
        
        public bool ContainsValue(int value)
        {
            return Enumerable.Range(From, To).Contains(value);
        }
    }
}