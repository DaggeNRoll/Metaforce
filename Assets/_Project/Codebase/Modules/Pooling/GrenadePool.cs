using System.Collections.Generic;
using _Project.Codebase.Modules.Player.Guns.Projectiles;
using UnityEngine;
using UnityEngine.Pool;

namespace _Project.Codebase.Modules.Pooling
{
    public class GrenadePool : MonoBehaviour
    {
        [SerializeField] private Grenade grenadePrefab;
        public IObjectPool<Grenade> Pool { get; private set; }

        private void Awake()
        {
            Pool =
                new ObjectPool<Grenade>(CreateGrenade, OnGetGrenade, OnReleaseGrenade, OnDestroyGrenade, 
                    true, 10, 10);

            var tempList = new List<Grenade>();
            for (int i = 0; i < 10; i++)
            {
                var grenade = Pool.Get();
                tempList.Add(grenade);
            }

            foreach (var grenade in tempList)
            {
                Pool.Release(grenade);
            }
        }

        private void OnDestroyGrenade(Grenade obj)
        {
            Destroy(obj.gameObject);
        }

        private void OnReleaseGrenade(Grenade obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void OnGetGrenade(Grenade obj)
        {
            obj.gameObject.SetActive(true);
        }

        private Grenade CreateGrenade()
        {
            return Instantiate(grenadePrefab, transform);
        }
    }
}