using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Project.Codebase.Modules.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> spawningPositions;
        
        private Enemy.Factory _enemyFactory;

        [Inject]
        public void Construct(Enemy.Factory factory)
        {
            _enemyFactory = factory;
        }

        private void Start()
        {
            foreach (var position in spawningPositions)
                SpawnEnemyWithPosition(position.position);
        }

        public void SpawnEnemy()
        {
            var enemy = _enemyFactory.Create();
            enemy.transform.position = spawningPositions[Random.Range(0, spawningPositions.Count)].position;
        }

        private void SpawnEnemyWithPosition(Vector3 position)
        {
            var enemy = _enemyFactory.Create();
            enemy.transform.position = position;
        }
    }
}