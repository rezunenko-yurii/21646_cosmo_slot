using System;

namespace StateMachine
{
    public interface IState
    {
        IState[] States { get; }
        void SwitchTo(Enum state);
    }
}