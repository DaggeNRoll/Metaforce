using _Project.Codebase.Modules.Enemy;
using _Project.Codebase.Modules.Pooling;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private BulletPool bulletPool;
        [SerializeField] private GrenadePool grenadePool;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private Enemy enemyPrefab;

        public override void InstallBindings()
        {
            Container.Bind<BulletPool>().FromInstance(bulletPool).AsSingle();
            Container.Bind<GrenadePool>().FromInstance(grenadePool).AsSingle();
            Container.Bind<EnemySpawner>().FromInstance(enemySpawner).AsSingle();
            Container.BindFactory<Enemy, Enemy.Factory>().FromSubContainerResolve().ByNewContextPrefab(enemyPrefab);
        }
    }
}