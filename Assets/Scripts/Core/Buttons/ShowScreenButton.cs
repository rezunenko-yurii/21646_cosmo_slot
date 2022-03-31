using Core.GameScreens;
using UnityEngine;

namespace Core.Buttons
{
    public class ShowScreenButton : ScreenButton
    {
        protected override void OnClick()
        {
            base.OnClick();
        
            Debug.Log($"{nameof(ShowScreenButton)} {nameof(OnClick)} show {screenId}");
            ScreensManager.Show(screenId);
        }
    }
}
