using System.Collections.Generic;
using Conditions.Models;
using ConditionsImp;
using Core.Conditions;
using Dates;
using Zenject;

namespace Conditions
{
    public class ConditionsTimers
    {
        [Inject] private DiContainer _container;
        [Inject] private ConditionsImp.Conditions _conditions;
        public Dictionary<ConditionModel, ConditionTimer> All { get; private set; }

        public void Init(Dictionary<ConditionModel, ConditionTimer> all)
        {
            All = all;
            //CreateTimers();
        }
        
        private void CreateTimers()
        {
            All = new Dictionary<ConditionModel,ConditionTimer>();
            
            foreach (var model in _conditions.All)
            {
                if (model.Key is ITimerRequest timerRequest)
                {
                    var nextDate = new NextDateKeeper(model.Key.Id);
                    
                    var timer = new ConditionTimer(nextDate, model.Key, model.Value);
                    timer.Init();
                    
                    _container.Bind<ConditionTimer>().FromInstance(timer).AsTransient();
                    //var timer = new ConditionTimer(nextDate, model.Key, model.Value);
                    All.Add(model.Key, timer);
                    
                }
            }
        }
    }
}