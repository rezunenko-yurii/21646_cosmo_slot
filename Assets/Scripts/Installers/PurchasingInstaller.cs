using Core.Finances.Payments;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PurchasingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log($"{nameof(PurchasingInstaller)} Start InstallBindings --------------");

            
        
            
            Debug.Log($"{nameof(PurchasingInstaller)} End InstallBindings --------------");
        }
    }
}