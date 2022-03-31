using Core.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachine.StateCheckers.Switchers.Duals
{
    [RequireComponent(typeof(NormalButton))]
    public class ButtonDisableSwitcher : Switcher
    {
        [SerializeField] private NormalButton button;
        
        public override void OnTrue()
        {
            button.SetNoClickable();
        }

        public override void OnFalse()
        {
            button.SetClickable();
        }
    }
}