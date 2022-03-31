using System;
using Core.Signals.Base;
using Zenject;

namespace Core.Signals.GameSignals
{
    public class SignalsHelper
    {
        [Inject] protected SignalBus SignalBus;
        [Inject] protected DiContainer Container;

        private SignalsPool Pool => new SignalsPool();

        public void DeclareSignal<TSignal>() => SignalBus.DeclareSignal<TSignal>();

        public void Declare<TSignal, TTarget>(Action<TSignal> handle) 
            where TSignal : GameSignal<TTarget>
            where TTarget : IIdentifier
        {
            DeclareSignal<TSignal>();
            SignalBus.Subscribe(handle);
            CreateEventNotifier<TSignal, TTarget>();
        }

        public void CreateEventNotifier<TSignal, TTarget>() 
            where TSignal : GameSignal<TTarget> 
            where TTarget : IIdentifier
        {
            var e = Container.Instantiate<EventNotifier<TSignal, TTarget>>();
            e.Initialize();
            Container.Bind<EventNotifier<TSignal, TTarget>>().FromInstance(e).AsSingle();
        }

        public void Fire(Type signalType, IIdentifier target)
        {
            var signal = Pool.GetSignal(signalType);
            Fire(signal as GameSignal, target);
        }

        public void Fire(GameSignal signal, IIdentifier target)
        {
            signal.Target = target;
            SignalBus.Fire(signal as object);
        }
    }
}