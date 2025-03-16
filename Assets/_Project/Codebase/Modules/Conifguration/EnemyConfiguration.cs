using UnityEngine;

namespace _Project.Codebase.Modules.Conifguration
{
    [CreateAssetMenu(menuName = "Configs/Enemy", fileName = "EnemyConfiguration", order = 0)]
    public class EnemyConfiguration : Configuration
    {
        [field: SerializeField] public int StartingHealth { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
    }
}