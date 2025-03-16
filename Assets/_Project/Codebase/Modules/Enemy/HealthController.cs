using System;
using _Project.Codebase.Common;
using _Project.Codebase.Modules.Conifguration;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Enemy
{
    public class HealthController : MonoBehaviour, IHealth
    {
        private EnemyConfiguration _enemyConfiguration;
        private int _currentHealth;

        public event Action Dead;

        [Inject]
        public void Construct(ConfigurationService configurationService, EnemySpawner enemySpawner)
        {
            _enemyConfiguration = configurationService.GetConfiguration<EnemyConfiguration>();

            _currentHealth = _enemyConfiguration.StartingHealth;
        }

        public void SetDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Dead?.Invoke();
            }
        }

        public void Revive()
        {
            _currentHealth = _enemyConfiguration.StartingHealth;
        }
    }
}