using Core.Popups;
using DefaultNamespace;
using Installers;
using UnityEngine;
using WelcomeBonusLib;

namespace WelcomeBonus
{
    public class WelcomeBonusInstaller : AdvancedMonoInstaller
    {
        public override void InstallBindings()
        {
            if (!use)
            {
                Debug.LogWarning("Current Installer is disabled");
                return;
            }
            
            Container.Bind<WelcomeBonus>().AsSingle().NonLazy();
            
            var welcomeBonusOnStart = Container.Instantiate<WelcomeBonusOnStart>();
            welcomeBonusOnStart.popupId = "popup.welcome";
            Container.Bind<WelcomeBonusOnStart>().FromInstance(welcomeBonusOnStart).AsSingle();
        }
    }
}