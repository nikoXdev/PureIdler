using R3;
using Sources.Runtime.Core.Contracts;

namespace Sources.Runtime.Services.Wallet
{
    public sealed class WalletService : IWalletService
    {
        public ReactiveProperty<long> Money { get; private set; } = new(0);

        public bool TryAddMoney(long amount)
        {
            if (amount < 0)
                return false;
            
            Money.Value += amount;
            
            return true;
        }

        public bool TrySpendMoney(long amount)
        {
            if (Money.Value < amount) 
                return false;
            
            Money.Value -= amount;
            
            return true;
        }
    }
}