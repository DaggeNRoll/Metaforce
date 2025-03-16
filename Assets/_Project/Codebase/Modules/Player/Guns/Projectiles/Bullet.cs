using System;
using System.Linq;
using _Project.Codebase.Common;
using _Project.Codebase.Modules.Conifguration;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Player.Guns.Projectiles
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        
        private GunConfig _config;
        
        public event Action<Bullet> ReturnToPool;

        [Inject]
        public void Construct(ConfigurationService config)
        {
            _config = config.GetConfiguration<GunsConfiguration>().GunConfigs
                .First(x => x.GunType == GunType.Pistol);
        }

        public void Shoot(Vector3 direction)
        {
            rigidbody.AddForce(direction * 300, ForceMode.Force);
            Invoke(nameof(ReturnToPoolAfterDelay), 40);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IHealth health))
            {
                health.SetDamage(_config.Damage);
            }
            rigidbody.linearVelocity = Vector3.zero;
            CancelInvoke(nameof(ReturnToPoolAfterDelay));
            ReturnToPool?.Invoke(this);
        }

        private void ReturnToPoolAfterDelay()
        {
            rigidbody.linearVelocity = Vector3.zero;
            ReturnToPool?.Invoke(this);
        }
        
        public class Factory : PlaceholderFactory<Bullet>{}
    }
}