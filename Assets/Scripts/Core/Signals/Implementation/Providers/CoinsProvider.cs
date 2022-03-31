using Core.Finances.Moneys;
using Users;
using Zenject;

namespace Core.Signals.Implementation.Providers
{
    public class CoinsProvider : ProductProvider<Coins>
    {
        [Inject] private User _user;
        
        public override void Handle(Coins coins)
        {
            _user.Wallets.Add(coins);
        }
    }
}