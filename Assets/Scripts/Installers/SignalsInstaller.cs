using SlotsGame.Scripts;
using SlotsGame.Scripts.Bets;
using SlotsGame.Scripts.Slot;
using Zenject;

namespace Installers
{
    public class SignalsInstaller : MonoInstaller
    {
        [Inject] private SignalBus _signalBus;
        public override void InstallBindings()
        {
            _signalBus.DeclareSignal<BetSignals.Used>();
            
            _signalBus.DeclareSignal<Signal.Spin>();
            _signalBus.DeclareSignal<Signal.SpinOver>();
            
            _signalBus.DeclareSignal<Game.Signal.SpinStarted>();
            _signalBus.DeclareSignal<Game.Signal.SpinEnded>();
            _signalBus.DeclareSignal<Game.Signal.EffectsStarted>();
            _signalBus.DeclareSignal<Game.Signal.EffectsEnded>();
            _signalBus.DeclareSignal<Game.Signal.RoundEnded>();
        }
    }
}