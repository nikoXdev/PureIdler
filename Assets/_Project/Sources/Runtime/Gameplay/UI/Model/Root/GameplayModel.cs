using Sources.Runtime.Gameplay.Root;

namespace Sources.Runtime.Gameplay.UI.Model.Root
{
    public sealed class GameplayModel : IGameplayModel
    {
        public int IncreaseMoneyByClick { get; private set; }

        public GameplayModel(GameData gameData)
        {
            IncreaseMoneyByClick = gameData.StartingClickPower;
        }
    }
}