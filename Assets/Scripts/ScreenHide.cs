using Core;
using Core.Buttons;
using Core.GameScreens;
using UnityEngine;
using Zenject;

public class ScreenHide : NormalButton
{
    [Inject] protected ScreensManager ScreensManager;
    protected GameScreen CurrentScreen;
    
    protected override void OnClick()
    {
        base.OnClick();
        TryHide();
    }

    protected virtual void TryHide()
    {
        CurrentScreen = ScreensManager.GetLast();
        CurrentScreen.Hidden += OnHidden;
        ScreensManager.HideLast();
    }

    protected virtual void OnHidden(IUIObject obj)
    {
        CurrentScreen.Hidden -= OnHidden;
        CurrentScreen = null;
    }
}