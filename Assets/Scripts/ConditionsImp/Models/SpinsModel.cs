using Conditions;
using Conditions.Models;
using Core.Conditions;
using Core.GameScreens;
using UnityEngine;

namespace ConditionsImp.Models
{
    [CreateAssetMenu(fileName = "SpinsUsed Model", menuName = "Conditions/Models/SpinsUsed")]
    public class SpinsModel : ConditionModel, ILocationRequest
    {
        [field: SerializeField] public string Location { get; private set; }
    }
}