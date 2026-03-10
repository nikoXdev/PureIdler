using R3;
using Sources.Runtime.Core.MVP.Presenter;
using Sources.Runtime.Core.ServiceLocator;
using Sources.Runtime.Gameplay.UI.Model.Root;
using Sources.Runtime.Gameplay.UI.View.Root;
using Sources.Runtime.Services.Wallet;

namespace Sources.Runtime.Gameplay.UI.Presenter.Root
{
    public sealed class GameplayPresenter : PresenterBase<IGameplayModel, IGameplayView>, IService
    {
        private readonly IWalletService _walletService;
        private readonly CompositeDisposable _compositeDisposable;
        
        public GameplayPresenter(IGameplayModel model, IGameplayView view, IWalletService walletService) : base(model, view)
        {
            _walletService = walletService;
            
            _compositeDisposable = new CompositeDisposable();
        }

        public override void Initialize()
        {
            _walletService.Money.Subscribe(value =>
            {
                View.DisplayMoney(value);
            }).AddTo(_compositeDisposable);
            
            View.OnClicked += OnClicked;
        }

        public override void Dispose()
        {
            View.OnClicked -= OnClicked;
            
            _compositeDisposable.Dispose();
        }

        private void OnClicked()
        {
            _walletService.TryAddMoney(Model.IncreaseMoneyByClick);
        }
    }
}