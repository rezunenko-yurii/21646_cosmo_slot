using Core.Buttons;
using StateMachine.Commands;
using StateMachine.States;

namespace StateMachine
{
    public class CommandButton : NormalButton
    {
        public BaseCommand command;

        protected override void OnClick()
        {
            base.OnClick();
            command.Handle();
        }
    }
}
