using System;
using Core;
using Core.GameScreens;
using Zenject;

namespace SlotsGame.Scripts.Bets
{
    public class BetsManager : AdvancedObject
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ScreensManager _screensManager;
        
        public Action<int> Changed;
        private int _current;

        protected override void AddListeners()
        {
            base.AddListeners();
            _signalBus.Subscribe<Game.Signal.SpinStarted>(OnSpin);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _signalBus.Unsubscribe<Game.Signal.SpinStarted>(OnSpin);
        }
        
        private void OnSpin()
        {
            _signalBus.Fire(new BetSignals.Used(_current, _screensManager.Current.Id));
        }

        public int Current
        {
            get => _current;
            set
            {
                _current = value;
                Changed?.Invoke(_current);
            }
        }
    }
}