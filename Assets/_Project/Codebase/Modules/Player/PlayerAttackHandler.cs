using System;
using System.Collections.Generic;
using _Project.Codebase.Modules.Player.Guns;
using _Project.Codebase.Modules.Pooling;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Codebase.Modules.Player
{
    public class PlayerAttackHandler : MonoBehaviour
    {
        [SerializeField] private Transform muzzlePoint;

        private GunFactory _gunFactory;
        private EnemyObserver _enemyObserver;
        private BulletPool _bulletPool;
        private GrenadePool _grenadePool;
        private IInputHandler _inputHandler;

        private Dictionary<Type, IGun> _guns;

        private IGun _currentGun;
        private Transform _attackTarget;

        [Inject]
        public void Construct(GunFactory gunFactory,
            EnemyObserver enemyObserver, BulletPool bulletPool, GrenadePool grenadePool, IInputHandler inputHandler)
        {
            _gunFactory = gunFactory;
            _enemyObserver = enemyObserver;
            _bulletPool = bulletPool;
            _grenadePool = grenadePool;
            _inputHandler = inputHandler;
        }

        private void Awake()
        {
            _guns = new Dictionary<Type, IGun>
            {
                { typeof(Pistol), _gunFactory.CreateGun<Pistol>() },
                { typeof(Grenade), _gunFactory.CreateGun<Grenade>() }
            };

            SelectGun<Pistol>();
        }

        private void Start()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }

        private void Update()
        {
            if(_attackTarget == null)
                return;
            
            _currentGun?.Shoot(_attackTarget.position - muzzlePoint.position, muzzlePoint.position);
        }

        private void SelectGun<T>() where T : class, IGun
        {
            _currentGun = _guns[typeof(T)];
        }

        private void Initialize()
        {
            _enemyObserver.ClosestObservableFound += OnClosesEnemyFound;
            _enemyObserver.NoObservableFound += OnNoEnemiesFound;
            _inputHandler.WeaponChanged += OnWeaponChanged;
        }

        private void OnWeaponChanged()
        {
            if(_currentGun.GetType() == typeof(Pistol))
                SelectGun<Grenade>();
            else
            {
                SelectGun<Pistol>();
            }
        }

        private void OnClosesEnemyFound(Transform obj)
        {
            _attackTarget = obj;
        }

        private void OnNoEnemiesFound()
        {
            _attackTarget = null;
        }

        private void Dispose()
        {
            _enemyObserver.ClosestObservableFound -= OnClosesEnemyFound;
            _enemyObserver.NoObservableFound -= OnNoEnemiesFound;
            _inputHandler.WeaponChanged -= OnWeaponChanged;
        }
    }
}