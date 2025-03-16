using System;
using System.Linq;
using _Project.Codebase.Common;
using _Project.Codebase.Modules.Conifguration;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Player.Guns.Projectiles
{
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private float flightTime;
        [SerializeField] private Rigidbody rigidBody;
        
        private GunConfig _gunConfig;
        private Collider[] _hits = new Collider[10];
        public event Action<Grenade> ReturnToPool;

        [Inject]
        public void Construct(ConfigurationService configurationService)
        {
            _gunConfig = configurationService.GetConfiguration<GunsConfiguration>().GunConfigs
                .First(x => x.GunType == GunType.Grenade);
        }
        
        public void Launch(Vector3 direction)
        {
            rigidBody.AddForce(direction * 100, ForceMode.Force);
            Invoke(nameof(ReturnToPoolAfterDelay), 40);
        }

        private void OnCollisionEnter(Collision other)
        {
            DoSplashDamage();
            rigidBody.linearVelocity = Vector3.zero;
            ReturnToPool?.Invoke(this);
        }

        private void DoSplashDamage()
        {
            var hitsCount = Physics.OverlapSphereNonAlloc(transform.position, 3f, _hits);

            for (int i = 0; i < hitsCount; i++)
            {
                if (_hits[i].TryGetComponent(out IHealth health))
                {
                    health.SetDamage(_gunConfig.Damage);
                }
            }
        }

        private void ReturnToPoolAfterDelay()
        {
            rigidBody.linearVelocity = Vector3.zero;
            ReturnToPool?.Invoke(this);
        }
        
        public class Factory : PlaceholderFactory<Grenade>{}
    }
}