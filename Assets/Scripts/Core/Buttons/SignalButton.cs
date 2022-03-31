using Core.GameScreens;
using UnityEngine;
using Zenject;

namespace Core.Buttons
{
    public class SignalButton : NormalButton
    {
        [Inject] protected SignalBus signalBus;
    }
}
