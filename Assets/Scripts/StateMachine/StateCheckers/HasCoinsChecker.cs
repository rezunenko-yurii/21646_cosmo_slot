using Core.Finances.Moneys;
using UnityEngine;
using Users;
using Zenject;

namespace StateMachine.StateCheckers
{
    public class HasCoinsChecker : DualStateChecker
    {
        [SerializeField] private Coins _coins;
        [Inject] private User user;
        
        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            Check();
        }

        private void Check()
        {
            if (user.Wallets.HasOnBalance(_coins))
            {
                SetAllActive();
            }
            else
            {
                SetAllInactive();
            }
        }
    }
}