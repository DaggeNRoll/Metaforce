using System;
using System.Collections;
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
        private WaitForSeconds _delay = new WaitForSeconds(5f);

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

        public void RespawnEnemyWithDelay(Enemy enemy)
        {
            StartCoroutine(RespawnWithDelay(enemy));
        }

        private void SpawnEnemyWithPosition(Vector3 position)
        {
            var enemy = _enemyFactory.Create();
            enemy.transform.position = position;
            enemy.Reset();
        }

        private IEnumerator RespawnWithDelay(Enemy enemy)
        {
            yield return _delay;
            
            var position = spawningPositions[Random.Range(0, spawningPositions.Count)];
            enemy.transform.position = position.position;
            enemy.Reset();
        }
    }
}