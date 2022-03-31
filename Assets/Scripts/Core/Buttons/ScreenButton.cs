using Core.GameScreens;
using UnityEngine;
using Zenject;

namespace Core.Buttons
{
    public class ScreenButton : SignalButton
    {
        [Inject] protected ScreensManager ScreensManager;
        [SerializeField] protected string screenId;
    }
}