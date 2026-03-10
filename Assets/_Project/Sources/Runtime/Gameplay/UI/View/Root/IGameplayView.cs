using System;
using Sources.Runtime.Core.MVP.View;

namespace Sources.Runtime.Gameplay.UI.View.Root
{
    public interface IGameplayView : IView
    {
        event Action OnClicked;
        
        void DisplayMoney(long amount);
    }
}