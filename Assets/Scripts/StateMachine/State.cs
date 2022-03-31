using System;
using StateMachine.StateCheckers.Switchers;
using UnityEngine;

namespace StateMachine
{
    public class State : IState
    {
        /*protected Switcher switcher;
        
        public void SetContext(Switcher switcher)
        {
            this.switcher = switcher;
        }*/
        public IState[] States { get; }
        public void SwitchTo(Enum state)
        {
            throw new NotImplementedException();
        }
    }
}