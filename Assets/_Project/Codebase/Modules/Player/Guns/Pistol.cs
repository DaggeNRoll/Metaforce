using System.Collections.Generic;
using System.Linq;
using _Project.Codebase.Modules.Conifguration;
using _Project.Codebase.Modules.Player.Guns.Projectiles;
using _Project.Codebase.Modules.Pooling;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Player.Guns
{
    public class Pistol : IGun
    {
        private GunConfig _config;
        private BulletPool _bulletPool;
        private float _lastShotTime = -10f;
        
        [Inject]
        public Pistol(ConfigurationService configurationService, BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
            _config = configurationService.GetConfiguration<GunsConfiguration>().GunConfigs
                .First(x => x.GunType == GunType.Pistol);
        }

        public void Shoot(Vector3 direction, Vector3 shootPoint)
        {
            if(_lastShotTime + _config.FireRate > Time.time)
                return;
            var bullet = _bulletPool.Pool.Get();
            bullet.transform.position = shootPoint;
            bullet.Shoot(direction);
            bullet.ReturnToPool += OnShot;
            _lastShotTime = Time.time;
        }

        private void OnShot(Bullet obj)
        {
            obj.ReturnToPool -= OnShot;
            _bulletPool.Pool.Release(obj);
        }
    }
}