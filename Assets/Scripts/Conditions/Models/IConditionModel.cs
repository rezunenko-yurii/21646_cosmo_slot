using System.Collections.Generic;
using Core.Finances.Store.Products;

namespace Core.Conditions
{
    public interface IConditionModel
    {
        string Id { get; }
        bool IsFulfilled { get; }
        int CurrentAmount { get; }
        int TargetAmount { get; }
        string Rewards { get; }
        void Reset();
    }
}