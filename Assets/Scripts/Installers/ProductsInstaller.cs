using Core.Finances;
using Core.Finances.Moneys;
using Core.Finances.Payments;
using Core.Finances.Store;
using Core.Finances.Store.Products;
using Core.Signals.Base;
using Finances.Moneys;
using Finances.Store.Models;
using GameSignals;
using UnityEngine;
using WalletsImp;
using Zenject;

namespace Installers
{
    public class ProductsInstaller : MonoInstaller
    {
        [SerializeField] private TextAsset productConfig;
        [SerializeField] private TextAsset productPackConfig;
        [SerializeField] private TextAsset productPacksConfig;
        [SerializeField] private TextAsset merchandisesConfig;
        [SerializeField] private TextAsset subscribersConfig;
        public override void InstallBindings()
        {
            InstallSignals();
            
            SignalEvents datas = new SignalEvents();
            datas.Init(subscribersConfig);
            Container.Bind<SignalEvents>().FromInstance(datas).AsSingle();
            
            Container.Bind<Moneys>().AsSingle().NonLazy();
            Container.Bind<Products>().AsSingle().OnInstantiated<Products>((_, products) => products.Init(productConfig)).NonLazy();

            var productPackProvider = Container.Instantiate<Bundles>();
            productPackProvider.Init(productPackConfig);
            Container.Bind<Bundles>().FromInstance(productPackProvider).NonLazy();
            
            var productPacksProvider = Container.Instantiate<ProductBundlesSets>();
            productPacksProvider.Init(productPacksConfig);
            Container.Bind<ProductBundlesSets>().FromInstance(productPacksProvider).NonLazy();
            
            Merchandises merchandises = Container.Instantiate<Merchandises>();
            merchandises.Init(merchandisesConfig);
            Container.Bind<Merchandises>().FromInstance(merchandises).NonLazy();
        }
        
        private void InstallSignals()
        {
            Container.DeclareSignal<PurchaseFailed<IProduct>>();
            Container.DeclareSignal<PurchaseFailed<Bundle>>();
            Container.DeclareSignal<PurchaseFailed<Merchandise>>();
            
            
            Container.DeclareSignal<MoneySignals.Added<Coins>>();
            Container.DeclareSignal<MoneySignals.Subtracted<Coins>>();
            Container.DeclareSignal<MoneySignals.Changed<Coins>>();
            
            Container.DeclareSignal<MoneySignals.Added<Spins>>();
            Container.DeclareSignal<MoneySignals.Subtracted<Spins>>();
            Container.DeclareSignal<MoneySignals.Changed<Spins>>();
            
            Container.DeclareSignal<SpinsSignals.Spent>();
        }
    }
}