using Core.Moneys;

namespace Core.Wallets
{
    public interface IWallet
    {
        float Balance();
        void Add(IMoney amount);
        void Subtract(IMoney amount);
        bool CanSubtract(IMoney amount);
        bool CanDecreaseInMinus { get; }
        void Reset();
    }
}