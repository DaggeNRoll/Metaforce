using System;
using _Project.Codebase.Modules.Coins;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Random = UnityEngine.Random;

namespace _Project.Codebase.Modules.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent navMeshAgent;
        [SerializeField] 
        private float radius = 10f;
        
        private Coin.Factory _coinFactory;
        private HealthController _healthController;
        private EnemySpawner _enemySpawner;

        [Inject]
        public void Construct(Coin.Factory coinFactory,HealthController healthController, EnemySpawner enemySpawner)
        {
            _coinFactory = coinFactory;
            _healthController = healthController;
            _enemySpawner = enemySpawner;
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
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                SetWaypoint();
            }
        }

        public void Reset()
        {
            gameObject.SetActive(true);
            SetWaypoint();
            _healthController.Revive();
        }

        private void Initialize()
        {
            _healthController.Dead += OnDead;
        }

        private void Dispose()
        {
            _healthController.Dead -= OnDead;
        }

        private void OnDead()
        {
            navMeshAgent.isStopped = true;
            var coin = _coinFactory.Create();
            coin.transform.position = transform.position;
            gameObject.SetActive(false);
            _enemySpawner.RespawnEnemyWithDelay(this);
        }

        private void SetWaypoint()
        {
            var randomPoint = Random.insideUnitSphere * radius;
            randomPoint += transform.position;
            NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, radius, NavMesh.AllAreas);
            navMeshAgent.destination = hit.position;
        }
        
        public class Factory : PlaceholderFactory<Enemy>{}
    }
}