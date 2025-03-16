using UnityEngine;

namespace _Project.Codebase.Modules.Conifguration
{
    public class EnemyConfiguration : Configuration
    {
        [field: SerializeField] public int StartingHealth { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
    }
}