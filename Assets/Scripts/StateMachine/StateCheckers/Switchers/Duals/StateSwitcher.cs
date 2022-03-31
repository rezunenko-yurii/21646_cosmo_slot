using StateMachine.Commands;
using StateMachine.StateCheckers.Switchers.Duals;
using StateMachine.States;
using UnityEngine;

namespace StateMachine.Common
{
    [RequireComponent(typeof(CommandButton))]
    public class StateSwitcher : Switcher
    {
        [SerializeField] private BaseCommand activeState;
        [SerializeField] private BaseCommand inactiveState;
        [SerializeField] private CommandButton commandButton;

        private void Awake()
        {
            commandButton = GetComponent<CommandButton>();
        }

        public override void OnTrue()
        {
            commandButton.command = activeState;
        }
        
        public override void OnFalse()
        {
            commandButton.command = inactiveState;
        }
    }
}