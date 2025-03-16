using System;
using UnityEngine;

namespace _Project.Codebase.Modules.Player.Guns.Projectiles
{
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private float flightTime;
        [SerializeField] private Rigidbody rigidBody;
        public event Action<Grenade> ReturnToPool;
        

        public void Launch(Vector3 direction)
        {
            rigidBody.AddForce(direction * 100, ForceMode.Force);
            Invoke(nameof(ReturnToPoolAfterDelay), 40);
        }

        private void OnCollisionEnter(Collision other)
        {
            ReturnToPool?.Invoke(this);
            rigidBody.linearVelocity = Vector3.zero;
        }
        
        private void ReturnToPoolAfterDelay()
        {
            rigidBody.linearVelocity = Vector3.zero;
            ReturnToPool?.Invoke(this);
        }
    }
}