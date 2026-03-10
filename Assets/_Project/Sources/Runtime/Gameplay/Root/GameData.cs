using UnityEngine;

namespace Sources.Runtime.Gameplay.Root
{
    [CreateAssetMenu(menuName = "Data/Game", fileName = "GameData")]
    public sealed class GameData : ScriptableObject
    {
        [field: SerializeField] public int StartingMoney { get; private set; }
        [field: SerializeField] public int StartingClickPower { get; private set; }
    }
}