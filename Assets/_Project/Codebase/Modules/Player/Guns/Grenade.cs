using System.Collections.Generic;
using System.Linq;
using _Project.Codebase.Modules.Conifguration;
using _Project.Codebase.Modules.Pooling;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Player.Guns
{
    public class Grenade : IGun
    {
        private GunConfig _config;
        private GrenadePool _grenadePool;
        private float _lastShotTime = -10f;

        [Inject]
        public Grenade(ConfigurationService configurationService, GrenadePool grenadePool)
        {
            _grenadePool = grenadePool;
            _config = configurationService.GetConfiguration<GunsConfiguration>().GunConfigs
                .First(x => x.GunType == GunType.Grenade);
        }

        public void Shoot(Vector3 direction, Vector3 position)
        {
            if(_lastShotTime + _config.FireRate > Time.time)
                return;
            var projectile = _grenadePool.Pool.Get();
            projectile.transform.position = position;
            projectile.ReturnToPool += OnReturnToPool;
            projectile.Launch(direction);
            
            _lastShotTime = Time.time;
        }

        private void OnReturnToPool(Projectiles.Grenade obj)
        {
            obj.ReturnToPool -= OnReturnToPool;
            _grenadePool.Pool.Release(obj);
        }
    }
}