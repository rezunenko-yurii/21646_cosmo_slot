using System.Collections.Generic;
using Conditions;
using Conditions.Models;
using ConditionsImp;
using Core.Conditions;
using Dates;
using Zenject;

namespace Installers
{
    public class ConditionsInstaller : MonoInstaller
    {
        [Inject] private TickableManager _tickableManager;
        
        public override void InstallBindings()
        {
            ConditionsImp.Conditions conditions = new ConditionsImp.Conditions();
            Container.Bind<ConditionsImp.Conditions>().FromInstance(conditions).AsSingle().NonLazy();
            
            /*ConditionsTimers timers = Container.Instantiate<ConditionsTimers>();
            
            Dictionary<ConditionModel, ConditionTimer> All = new Dictionary<ConditionModel, ConditionTimer>();
            foreach (var model in conditions.All)
            {
                if (model.Key is ITimerRequest timerRequest)
                {
                    var nextDate = new NextDateKeeper(model.Key.Id);
                    
                    var timer = new ConditionTimer(nextDate, model.Key, model.Value);
                    timer.Init();
                    
                    Container.Bind<ConditionTimer>().FromInstance(timer).AsTransient();
                    _tickableManager.AddFixed(timer);
                    All.Add(model.Key, timer);
                    
                }
            }
            timers.Init(All);
            Container.Bind<ConditionsTimers>().FromInstance(timers).AsSingle();*/
        }
    }
}