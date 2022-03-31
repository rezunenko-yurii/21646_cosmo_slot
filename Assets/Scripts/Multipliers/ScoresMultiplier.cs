using System;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Multipliers
{
    [Serializable]
    public class ScoresMultiplier : TimeBasedMultiplier
    {
        public override string Type { get; protected set; }
    }
}