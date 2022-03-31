
using UnityEngine;

namespace Shop.OnPurchaseStateChangedHandlers
{
    public class PurchaseInjector : MonoBehaviour
    {
        /*[SerializeField] private Products.ShopProduct shopProduct;
        private void Awake()
        {
            if (shopProduct is null)
            {
                return;
            }
        
            var a = transform.GetComponentsInChildren<MonoBehaviour>();
            foreach (var aa in a)
            {
                var type = aa.GetType();

                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(prop => prop.IsDefined(typeof(PurchaseRequestAttribute), true));

                var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(field => field.IsDefined(typeof(PurchaseRequestAttribute), true));
            
                foreach (var property in properties)
                {
                    property.SetValue(aa,shopProduct);
                }
            
                foreach (var field in fields)
                {
                    field.SetValue(aa,shopProduct);
                }
            }
        }*/
    }
}
