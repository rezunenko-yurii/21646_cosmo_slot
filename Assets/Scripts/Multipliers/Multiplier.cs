using Core.Finances.Store.Products;
using UnityEngine;

namespace Multipliers
{
    public abstract class Multiplier : Product, IMultiplier
    {
        [field: SerializeField] public float XAmount { get; protected set; }
    }
}