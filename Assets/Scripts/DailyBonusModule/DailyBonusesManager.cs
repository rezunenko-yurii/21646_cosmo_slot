using Core.Finances.Store.Products;
using Core.Signals.GameSignals;
using Core.Timers;
using DailyReward;
using Dates;
using GameSignals;
using Zenject;

namespace DailyBonusModule
{
    public class DailyBonusesManager
    {
        [Inject(Id = ModuleType.DailyBonus)] public EveryDayCounter counter;
        [Inject(Id = ModuleType.DailyBonus)] public NextDateKeeper nextDateKeeper;
        [Inject(Id = ModuleType.DailyBonus)] public MemoryTimer timer;
        
        [Inject] private ProductBundlesSets _productBundlesSets;
        [Inject] private Bundles _bundles;
        [Inject] private SignalBus _signalBus;

        public ProductBundlesSet DaysProducts { get; private set; }
        
        
        public void Init(string productPacksId)
        {
            DaysProducts = _productBundlesSets.GetObject(productPacksId);
        }
        
        public void GiveBonus()
        {
            var products = DaysProducts.Lists[counter.CurrentDay];
            _signalBus.Fire(new Won<Bundle>(products));
            //_signalBus.Fire(new Taken<ProductBundle>(products));
            
            counter.Update();
            nextDateKeeper.AddHoursFromNow(24);
        }

        public bool IsBonusAvailable()
        {
            return timer.IsExpired;
        }
    }
}