using UnityEngine;

namespace _Project.Codebase.Modules.Conifguration
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "Configs/Player")]
    public class PlayerConfiguration : Configuration
    {
        [field: SerializeField]
        public float MovementSpeed { get; private set; }
        [field: SerializeField]
        public float EnemyObserveRange { get; private set; }
    }
}