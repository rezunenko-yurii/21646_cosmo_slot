using Core.Finances.Store.Products;
using Finances.Wallets;

namespace Users
{
    public class User
    {
        public Wallets Wallets { get; }

        public User(Wallets wallets)
        {
            Wallets = wallets;
        }
    }
}