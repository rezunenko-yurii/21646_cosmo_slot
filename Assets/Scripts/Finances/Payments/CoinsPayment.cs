using System.Collections.Generic;
using Core.Finances.Moneys;
using Core.Finances.Payments;
using Core.Finances.Store;
using Core.Wallets;
using DefaultNamespace;
using UnityEngine;
using Users;
using Zenject;

namespace Finances.Payments
{
    public class CoinsPayment : PaymentSystem<Coins>
    {
        private IWallet coinsWallet;
        [Inject] private User user;

        public override void Init()
        {
            Debug.Log($"{nameof(CoinsPayment)} Init");
            
            base.Init();
            coinsWallet = user.Wallets.Wallet(typeof(Coins));
        }

        public override void Purchase(Merchandise merchandise)
        {
            Coins coins = merchandise.Price as Coins;

            if (coinsWallet.CanSubtract(coins))
            {
                coinsWallet.Subtract(coins);
                OnPurchased(merchandise);
            }
            else
            {
                OnPurchaseFailed(merchandise.Id,"Aren`t enough coins");
            }
        }

        public override void Restore()
        {
            Debug.Log($"{nameof(CoinsPayment)} {nameof(Restore)} can`t restore purchases");
        }
    }
}