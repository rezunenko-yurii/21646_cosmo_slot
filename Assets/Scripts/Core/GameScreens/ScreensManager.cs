using Core.Popups;
using UnityEngine;
using Zenject;

namespace Core.GameScreens
{
    public class ScreensManager : UIObjectsManager<GameScreen, GameScreens>
    {
        [Inject] private PopupsManager _popupsManager;

        public GameScreen Current { get; private set; }
        
        public override void Show(string id)
        {
            _popupsManager.TryHideLast();
            base.Show(id);
        }

        protected override void AddToActive(GameScreen uiObject)
        {
            base.AddToActive(uiObject);
            Current = uiObject;
        }
    }
}

