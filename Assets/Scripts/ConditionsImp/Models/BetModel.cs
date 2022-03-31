using Conditions;
using Conditions.Models;
using Core.Conditions;
using UnityEngine;

namespace ConditionsImp.Models
{
    [CreateAssetMenu(fileName = "BetModel Model", menuName = "Conditions/Models/BetModel")]
    public class BetModel : ConditionModel, ILocationRequest
    {
        [field: SerializeField] public string Location { get; private set; }
    }
}