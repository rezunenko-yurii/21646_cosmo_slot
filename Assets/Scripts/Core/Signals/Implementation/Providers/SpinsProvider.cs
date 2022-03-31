using Finances.Moneys;
using Users;
using Zenject;

namespace Core.Signals.Implementation.Providers
{
    public class SpinsProvider : ProductProvider<Spins>
    {
        [Inject] private User _user;

        public override void Handle(Spins spins)
        {
            _user.Wallets.Add(spins);
        }
    }
}