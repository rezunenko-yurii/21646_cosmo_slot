using Core;
using Core.Finances.Moneys;
using Core.Moneys;
using Core.Wallets;
using DefaultNamespace;
using Finances.Moneys;
using Finances.Wallets;
using TMPro;
using UnityEngine;
using Users;
using Zenject;

public class FreeSpinsPanel : AdvancedMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;

    [Inject] private User user;
    [Inject] private SignalBus _signalBus;

    private IWallet spinsWallet;

    protected override void Initialize()
    {
        base.Initialize();
        spinsWallet = user.Wallets.Wallet(typeof(Spins));
    }

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        ChangeText(spinsWallet.Balance());
    }

    protected override void AddListeners()
    {
        _signalBus.Subscribe<MoneySignals.Changed<Spins>>(OnChanged);
    }
    
    protected override void RemoveListeners()
    {
        _signalBus.Unsubscribe<MoneySignals.Changed<Spins>>(OnChanged);
    }

    private void OnChanged(MoneySignals.Changed<Spins> spins)
    {
        ChangeText(spins.Value);
    }
    
    private void ChangeText(float amount)
    {
        textField.text = amount.ToString();
    }
}
