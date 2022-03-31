using UnityEngine;

namespace StateMachine.Commands
{
    public abstract class BaseCommand : MonoBehaviour
    {
        public abstract void Handle();
    }
}