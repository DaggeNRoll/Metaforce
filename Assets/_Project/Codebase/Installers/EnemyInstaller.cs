using _Project.Codebase.Modules.Enemy;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private HealthController healthController;

        public override void InstallBindings()
        {
            Container.Bind<HealthController>().FromInstance(healthController).AsSingle();
        }
    }
}