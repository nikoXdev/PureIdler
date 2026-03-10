using Sources.Runtime.Core.ServiceLocator;
using Sources.Runtime.Gameplay.UI.Model.Root;
using Sources.Runtime.Gameplay.UI.Presenter.Root;
using Sources.Runtime.Gameplay.UI.View.Root;
using Sources.Runtime.Services.Wallet;
using UnityEngine;

namespace Sources.Runtime.Gameplay.Root
{
    public sealed class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private GameData _data;
        [SerializeField] private GameplayView _view;
        
        private GameplayServiceLocator _serviceLocator;
        
        private void Awake()
        {
            ServiceLocator.SetSceneLocator(_serviceLocator = new GameplayServiceLocator());

            _serviceLocator.TryRegisterService<IWalletService, WalletService>(new WalletService());
            RegisterUI();

            Initialize();
        }

        private void RegisterUI()
        {
            _serviceLocator.TryRegisterService(new GameplayPresenter(new GameplayModel(_data), _view, _serviceLocator.GetService<IWalletService>()));
        }

        private void Initialize()
        {
            _serviceLocator.GetService<GameplayPresenter>().Initialize();
            _serviceLocator.GetService<IWalletService>().TryAddMoney(_data.StartingMoney);
        }
    }
}
