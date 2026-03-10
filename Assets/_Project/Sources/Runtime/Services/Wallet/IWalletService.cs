using R3;
using Sources.Runtime.Core.ServiceLocator;

namespace Sources.Runtime.Services.Wallet
{
    public interface IWalletService : IService
    {
        ReactiveProperty<long> Money { get; }
        
        bool TryAddMoney(long amount);
        bool TrySpendMoney(long amount);
    }
}