using System;
using Sources.Runtime.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Runtime.Gameplay.UI.View.Root
{
    public sealed class GameplayView : MonoBehaviour, IGameplayView
    {
        public event Action OnClicked;
        
        [SerializeField] private Button _clickButton;
        [SerializeField] private TextMeshProUGUI _moneyText;

        private void OnEnable()
        {
            _clickButton.onClick.AddListener(HandleClick);
        }
        
        private void OnDisable()
        {
            _clickButton.onClick.RemoveListener(HandleClick);
        }
        
        private void HandleClick() => OnClicked?.Invoke();

        public void DisplayMoney(long amount)
        {
            _moneyText.SetText(MoneyFormatter.Format(amount));
        }
    }
}