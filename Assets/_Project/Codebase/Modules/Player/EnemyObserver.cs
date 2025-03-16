using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Codebase.Modules.Conifguration;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Player
{
    public class EnemyObserver : MonoBehaviour
    {
        [SerializeField] private LayerMask enemyLayers;

        private ConfigurationService _configurationService;
        private float _enemyObserveRange;
        private Collider[] _enemies = new Collider[10];

        public Action<Transform> ClosestObservableFound;
        public Action NoObservableFound;

        [Inject]
        public void Construct(ConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            FindObservations();
        }

        private void FindObservations()
        {
            var observersCount = Physics.OverlapSphereNonAlloc(transform.position, _enemyObserveRange, _enemies,
                enemyLayers, QueryTriggerInteraction.Collide);

            if (observersCount == 0)
            {
                NoObservableFound?.Invoke();
                return;
            }

            if (observersCount == 1)
            {
                ClosestObservableFound?.Invoke(_enemies[0].transform);
                return;
            }

            var closestEnemy = _enemies[0];

            for (int i = 1; i < observersCount; i++)
            {
                if (_enemies[i] == null)
                    break;

                if (Vector3.Distance(transform.position, closestEnemy.transform.position) >
                    Vector3.Distance(transform.position, _enemies[i].transform.position))
                {
                    closestEnemy = _enemies[i];
                }
            }
            
            ClosestObservableFound?.Invoke(closestEnemy.transform);
        }

        private void Initialize()
        {
            _enemyObserveRange = _configurationService.GetConfiguration<PlayerConfiguration>().EnemyObserveRange;
        }
    }
}