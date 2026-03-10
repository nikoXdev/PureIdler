using Sources.Runtime.Core.MVP.Model;

namespace Sources.Runtime.Gameplay.UI.Model.Root
{
    public interface IGameplayModel : IModel
    {
        int IncreaseMoneyByClick { get; }
    }
}