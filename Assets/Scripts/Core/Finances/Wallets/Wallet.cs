using Core.Collectables;
using Core.Finances.Moneys;
using Core.Moneys;
using Core.Wallets;
using UnityEngine;
using Zenject;

namespace Core.Finances.Wallets
{
    public abstract class Wallet<T> : IWallet where T: class, IMoney
    {
        [Inject] private SignalBus _signalBus;

        protected ICollectableObject<float> Collectable;

        public Wallet(ICollectableObject<float> collectableObject)
        {
            Collectable = collectableObject;
        }

        public float Balance() => Collectable.Amount;

        public void Add(IMoney amount) => Add(amount as T);

        public void Subtract(IMoney amount) => Subtract(amount as T);

        private void Add(T moneyToAdd)
        {
            Debug.Log($"{nameof(Wallet<T>)} {nameof(Add)} {moneyToAdd}");

            if (moneyToAdd.Amount > 0)
            {
                Collectable.Increase(moneyToAdd.Amount);

                FireAddedSignal(moneyToAdd.Amount);
                FireChangedSignal(Collectable.Amount);
            }
        }
        
        private void Subtract(T moneyToSubtract)
        {
            Debug.Log($"{nameof(Wallet<T>)} {nameof(Subtract)} {moneyToSubtract}");

            if (CanSubtract(moneyToSubtract))
            {
                Collectable.Decrease(moneyToSubtract.Amount);
                
                FireChangedSignal(Collectable.Amount );
                FireSpentSignal(moneyToSubtract.Amount); 
            }
            /*else
            {
                FireErrorSignal();
            }*/
        }
        
        public bool CanSubtract(IMoney amount) => (Collectable.Amount - amount.Amount) >= 0;

        public abstract bool CanDecreaseInMinus { get; protected set; }
        
        public void Reset()
        {
            Debug.Log($"{nameof(Wallet<T>)} {nameof(Reset)}");
            Collectable.Reset();
        }
        
        private void FireChangedSignal(float value)
        {
            _signalBus.Fire(new MoneySignals.Changed<T>(value));
        }
        private void FireAddedSignal(float value)
        {
            _signalBus.Fire(new MoneySignals.Added<T>(value));
        }
        private void FireSpentSignal(float value)
        {
            _signalBus.Fire(new MoneySignals.Subtracted<T>(value));
        }
    }
}