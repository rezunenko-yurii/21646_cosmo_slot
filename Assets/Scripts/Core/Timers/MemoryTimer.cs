using Dates;
using UnityEngine;

namespace Core.Timers
{
    public class MemoryTimer : Timer
    {
        public NextDateKeeper Keeper { get; }

        public MemoryTimer(NextDateKeeper nextDateKeeper)
        {
            Keeper = nextDateKeeper;
        }
        
        public override void Init()
        {
            if (IsInited)
            {
                Debug.LogWarning("MemoryTimer is already inited");
                return;
            }
            
            Keeper.Updated += OnDateUpdated;
            SetTimer(Keeper.Date);
        }
        
        private void OnDateUpdated()
        {
            SetTimer(Keeper.Date);
        }
    }
}