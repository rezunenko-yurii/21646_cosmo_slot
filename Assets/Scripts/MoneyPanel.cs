using System.Globalization;
using Core;
using Core.Finances.Moneys;
using Core.Moneys;
using Core.Wallets;
using DefaultNamespace;
using Finances.Wallets;
using TMPro;
using UnityEngine;
using Users;
using Zenject;

public class MoneyPanel : AdvancedMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amountText;
    
    [Inject] protected User user;
    private IWallet coinsWallet;
    
    [Inject] protected SignalBus SignalBus;

    protected override void Initialize()
    {
        base.Initialize();
        coinsWallet = user.Wallets.Wallet(typeof(Coins));
    }

    protected override void AddListeners()
    {
        SetAmountText(coinsWallet.Balance());
        SignalBus.Subscribe<MoneySignals.Changed<Coins>>(OnAdded);
    }
    
    protected override void RemoveListeners()
    {
        SignalBus.Unsubscribe<MoneySignals.Changed<Coins>>(OnAdded);
    }

    private void OnAdded(MoneySignals.Changed<Coins> obj)
    {
        SetAmountText(obj.Value);
    }

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        SetAmountText(coinsWallet.Balance());
    }

    private void SetAmountText(float amount)
    {
        var f = new NumberFormatInfo {NumberGroupSeparator = " "};
        amountText.text = amount.ToString("n0", f);
    }
}
