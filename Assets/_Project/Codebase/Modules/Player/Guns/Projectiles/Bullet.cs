using System;
using UnityEngine;

namespace _Project.Codebase.Modules.Player.Guns.Projectiles
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        
        public event Action<Bullet> ReturnToPool;

        public void Shoot(Vector3 direction)
        {
            rigidbody.AddForce(direction * 300, ForceMode.Force);
            Invoke(nameof(ReturnToPoolAfterDelay), 40);
        }

        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
                return;
            rigidbody.linearVelocity = Vector3.zero;
            CancelInvoke(nameof(ReturnToPoolAfterDelay));
            ReturnToPool?.Invoke(this);
        }

        private void ReturnToPoolAfterDelay()
        {
            rigidbody.linearVelocity = Vector3.zero;
            ReturnToPool?.Invoke(this);
        }
    }
}