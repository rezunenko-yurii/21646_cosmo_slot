using SlotsGame.Scripts;
using SlotsGame.Scripts.AutoSpins;
using SlotsGame.Scripts.AutoSpins.Modes;
using SlotsGame.Scripts.Bets;
using SlotsGame.Scripts.BoardLib;
using SlotsGame.Scripts.CellsLib;
using SlotsGame.Scripts.ChipsLib;
using SlotsGame.Scripts.Combinations;
using SlotsGame.Scripts.Lines;
using SlotsGame.Scripts.ReelsLib;
using SlotsGame.Scripts.Slot;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Config config;
        public override void InstallBindings()
        {
            Debug.Log($"{nameof(GameInstaller)} Start InstallBindings ------------");
            
            Container.Bind<Config>().FromInstance(config).AsSingle();
            
            Container.Bind<AutoSpinModesFactory>().AsSingle();
            Container.Bind<AutoSpin>().AsSingle().NonLazy();
            Container.Bind<CombinationHolder>().AsSingle();
            Container.Bind<Controls>().FromComponentInHierarchy().AsSingle();
            
            var lines = Container.Instantiate<LinesManager>();
            lines.Prepare();
            Container.Bind<LinesManager>().FromInstance(lines);
            
            Container.BindInterfacesAndSelfTo<BetsManager>().AsSingle();

            Container.Bind<CombinationRewards>().AsSingle();
            
            var roundCoinsWonWatcher = Container.Instantiate<RoundCoinsWonWatcher>();
            roundCoinsWonWatcher.Init();
            Container.Bind<RoundCoinsWonWatcher>().FromInstance(roundCoinsWonWatcher);
            
            Container.Bind<Reels>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Cells>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Selectors>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Chips>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<Board>().FromComponentInHierarchy().AsSingle();

            Debug.Log($"{nameof(GameInstaller)} End InstallBindings ----------------");
        }
    }
}