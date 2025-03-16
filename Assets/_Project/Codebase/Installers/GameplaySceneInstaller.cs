using _Project.Codebase.Modules.Coins;
using _Project.Codebase.Modules.Enemy;
using _Project.Codebase.Modules.Player.Guns.Projectiles;
using _Project.Codebase.Modules.Pooling;
using _Project.Codebase.Modules.UI;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private BulletPool bulletPool;
        [SerializeField] private GrenadePool grenadePool;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private CoinPanel coinPanel;
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Grenade grenadePrefab;
        [SerializeField] private Coin coinPrefab;

        public override void InstallBindings()
        {
            Container.Bind<BulletPool>().FromInstance(bulletPool).AsSingle();
            Container.Bind<GrenadePool>().FromInstance(grenadePool).AsSingle();
            Container.Bind<EnemySpawner>().FromInstance(enemySpawner).AsSingle();
            Container.Bind<CoinPanel>().FromInstance(coinPanel).AsSingle();
            Container.BindFactory<Enemy, Enemy.Factory>().FromSubContainerResolve().ByNewContextPrefab(enemyPrefab);
            Container.BindFactory<Bullet, Bullet.Factory>().FromSubContainerResolve().ByNewContextPrefab(bulletPrefab);
            Container.BindFactory<Grenade, Grenade.Factory>().FromSubContainerResolve().ByNewContextPrefab(grenadePrefab);
            Container.BindFactory<Coin, Coin.Factory>().FromSubContainerResolve().ByNewContextPrefab(coinPrefab);
        }
    }
}