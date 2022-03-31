using System;
using System.Collections.Generic;
using Core.Collectables;
using Core.Finances;
using Core.Finances.Moneys;
using Core.Finances.Store;
using Core.Finances.Store.Products;
using Core.Finances.Wallets;
using Core.Signals.GameSignals;
using Core.Wallets;
using Finances.Moneys;
using Finances.Payments;
using Finances.Payments.Unity;
using Finances.Wallets;
using Users;
using Zenject;

namespace Installers
{
    public class UserInstaller : MonoInstaller
    {
        private Wallets wallets;
        public override void InstallBindings()
        {
            Container.Bind<SignalsHelper>().AsSingle().NonLazy();
            CreateWallets();
            
            User user = new User(wallets);
            Container.Bind<User>().FromInstance(user).AsSingle();
            
            var coinsPayment = Container.Instantiate<CoinsPayment>();
            coinsPayment.Init();
            Container.Bind<CoinsPayment>().FromInstance(coinsPayment).AsSingle();
            
            var unityPayment = Container.Instantiate<UnityPayment>();
            unityPayment.Init();
            Container.Bind<UnityPayment>().FromInstance(unityPayment).AsSingle();
            
            var payments = Container.Instantiate<Payments>();
            payments.Init();
            Container.Bind<Payments>().FromInstance(payments).AsSingle();
        }

        private void CreateWallets()
        {
            FloatCollectableObject coinsCollectableObject = new FloatCollectableObject("coins",0);
            CoinsWallet coinsWallet = new CoinsWallet(coinsCollectableObject);
            Container.Inject(coinsWallet);
            
            FloatCollectableObject spinsCollectableObject = new FloatCollectableObject("spins",0);
            SpinsWallet spinsWallet = new SpinsWallet(spinsCollectableObject);
            Container.Inject(spinsWallet);

            Dictionary<Type, IWallet> dictionary = new Dictionary<Type, IWallet>()
            {
                {typeof(Coins), coinsWallet},
                {typeof(Spins), spinsWallet},
            };
            
            wallets = new Wallets(dictionary);
        }
    }
}