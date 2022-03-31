using Core.Buttons;
using UnityEngine;
using Zenject;

namespace Core.Popups.Buttons
{
    public class PopupButton : NormalButton
    {
        [Inject] protected PopupsManager PopupsManager;
    }
}