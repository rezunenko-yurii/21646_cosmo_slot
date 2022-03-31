using System;
using System.Collections.Generic;
using Conditions;
using Conditions.Models;
using Core.Conditions;
using UnityEngine;

namespace ConditionsImp
{
    public class Conditions
    {
        private ConditionModel[] _models;
        
        public Dictionary<ConditionModel, Condition> All { get; private set; }

        public Conditions()
        {
            _models = Resources.LoadAll<ConditionModel>("");
            Create();
        }

        private void Create()
        {
            All = new Dictionary<ConditionModel, Condition>();
            foreach (var model in _models)
            {
                All.Add(model, new Condition(model));
            }
        }
        
        public List<Condition> ConditionByType(Type conditionType)
        {
            var products = new List<Condition>();
            
            foreach (var product in All)
            {
                Type type = product.Key.GetType();

                if (type.Equals(conditionType))
                {
                    products.Add(product.Value);
                }
            }

            return products;
        }
    }
}