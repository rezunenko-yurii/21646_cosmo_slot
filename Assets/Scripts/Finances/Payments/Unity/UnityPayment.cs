using System.Collections.Generic;
using Core.Finances.Moneys;
using Core.Finances.Payments;
using Core.Finances.Store;
using UnityEngine;

namespace Finances.Payments.Unity
{
    public class UnityPayment : PaymentSystem<Dollars>
    {
        private UnityStoreListener _storeListener;
        
        public override void Init()
        {
            Debug.Log($"{nameof(UnityPayment)} Init");
            base.Init();
            
            _storeListener = new UnityStoreListener();
            _storeListener.Init(merchandises);
            
            _storeListener.Purchased += OnPurchased;
            _storeListener.PurchaseFailed += OnPurchaseFailed;
        }

        public override void Purchase(Merchandise merchandise)
        {
            Debug.Log($"{nameof(UnityPayment)} Purchase {merchandise.Id}");
            _storeListener.Purchase(merchandise.Id);
        }

        public override void Restore()
        {
            Debug.Log($"{nameof(UnityPayment)} Restore");
            _storeListener.RestorePurchases();
        }
    }
}