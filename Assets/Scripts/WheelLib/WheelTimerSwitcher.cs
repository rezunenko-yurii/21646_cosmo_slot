using Core.Timers;
using StateMachine;
using Zenject;

namespace WheelLib
{
    public class WheelTimerSwitcher : DualStateChecker
    {
        [Inject(Id = ModuleType.Wheel)] protected MemoryTimer Timer { get; }
        
        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            
            if (Timer.IsExpired)
            {
                SetAllActive();
            }
            else
            {
                SetAllInactive();
                Timer.Over += OnOver;
            }
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
            
            Timer.Over -= OnOver;
        }

        private void OnOver()
        {
            SetAllActive();
        }
    }
}