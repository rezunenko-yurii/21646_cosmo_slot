using Core.Timers;
using Dates;
using Lives;
using UnityEngine;
using Zenject;

namespace MemoryMatch.Scripts
{
    public class MemoryMatchInstaller : MonoInstaller
    {
        [Inject] private TickableManager _tickableManager;
        [Inject] private SignalBus _signalBus;
        [SerializeField] private TextAsset _levelsConfig;
        
        public override void InstallBindings()
        {
            _signalBus.DeclareSignal<Core.GameSignals.Pause>();
            _signalBus.DeclareSignal<Core.GameSignals.Resume>();
            _signalBus.DeclareSignal<Core.GameSignals.Restart>();
            _signalBus.DeclareSignal<Core.GameSignals.NextLevel>();
            
            _signalBus.DeclareSignal<Core.GameSignals.UserInputPause>();
            _signalBus.DeclareSignal<Core.GameSignals.UserInputResume>();
            
            _signalBus.DeclareSignal<ShowAllElementsSignal>();
            _signalBus.DeclareSignal<DestroyTwoElementsSignal>();

            var matchLevels = Container.Instantiate<Levels>();
            matchLevels.Init(_levelsConfig);
            Container.Bind<Levels>().FromInstance(matchLevels).AsSingle();

            var currentLevel = Container.Instantiate<LevelsManager>();
            currentLevel.Load();
            Container.Bind<LevelsManager>().FromInstance(currentLevel).AsSingle();

            NextDateKeeper nextDateKeeper = new NextDateKeeper("Lives");
            Container.Bind<NextDateKeeper>().FromInstance(nextDateKeeper);
            
            MemoryTimer timer = new MemoryTimer(nextDateKeeper);
            timer.Init();
            Container.Bind<MemoryTimer>().FromInstance(timer);
            _tickableManager.AddFixed(timer);
            
            var livesManager = Container.Instantiate<LivesManager>();
            livesManager.Init(3,180, timer);
            Container.Bind<LivesManager>().FromInstance(livesManager).AsSingle();
        }
    }
}