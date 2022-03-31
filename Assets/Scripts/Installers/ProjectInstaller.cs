using Core;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            Debug.Log($"{nameof(ProjectInstaller)} Start InstallBindings --------------");
            
            //SignalBusInstaller.Install(Container);

            //Container.Bind<IInitializable>().To<AdvancedObject>();

            //Container.DeclareSignal<GameSignals.Pause>();
            //Container.DeclareSignal<GameSignals.Resume>();
            
            Debug.Log($"{nameof(ProjectInstaller)} Start InstallBindings --------------");
        }
    }
}