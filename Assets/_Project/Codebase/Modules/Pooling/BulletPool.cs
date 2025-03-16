using System;
using System.Collections.Generic;
using _Project.Codebase.Modules.Player.Guns.Projectiles;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace _Project.Codebase.Modules.Pooling
{
    public class BulletPool : MonoBehaviour
    {
        private Bullet.Factory _bulletFactory;
        public IObjectPool<Bullet> Pool { get; private set; }

        [Inject]
        public void Construct(Bullet.Factory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        private void Awake()
        {
            Pool =
                new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, 
                    true, 10, 10);

            var tempList = new List<Bullet>();
            for (int i = 0; i < 10; i++)
            {
                var bullet = Pool.Get();
                tempList.Add(bullet);
            }

            foreach (var bullet in tempList)
            {
                Pool.Release(bullet);
            }
        }

        private void OnDestroyBullet(Bullet bullet)
        {
            Destroy(bullet.gameObject);
        }

        private void OnReleaseBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        private void OnGetBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
        }

        private Bullet CreateBullet()
        {
            var bullet = _bulletFactory.Create();
            bullet.transform.SetParent(transform);
            return bullet;
        }
    }
}