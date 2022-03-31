using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using Dates;
using GameSignals;
using UnityEngine;
using Zenject;

namespace WheelLib
{
    public class Wheels : MonoBehaviour
    {
        [SerializeField] private Wheel[] wheels;
        
        [Inject] private SignalBus _signalBus;
        [Inject(Id = ModuleType.Wheel)] private NextDateKeeper nextDateKeeper;

        public Wheel Current { get; private set; }
        private int _currentPosition;
        
        private void Awake()
        {
            Current = wheels[_currentPosition];
        }

        [ContextMenu("Spin")]
        public void Spin()
        {
            Debug.Log($"{nameof(Wheels)} {nameof(Spin)}");
            
            if (Current.Spinning)
            {
                Debug.Log($"{nameof(Wheels)} {nameof(Spin)} // Wheel already spinning");
                return;
            }

            Current.Spun += OnSpun;
            Current.TrySpin();
        }

        private void OnSpun()
        {
            Debug.Log($"{nameof(Wheels)} {nameof(OnSpun)}");
            GiveReward();

            Current.Spun -= OnSpun;
            nextDateKeeper.AddHoursFromNow(12);
        }

        private void GiveReward()
        {
            var sectorPosition = Current.GetSectorPosition();
            Bundle bundle = Current.SectorsRewards.Lists[sectorPosition];
            _signalBus.Fire(new Won<Bundle>(bundle));
        }
    }
}