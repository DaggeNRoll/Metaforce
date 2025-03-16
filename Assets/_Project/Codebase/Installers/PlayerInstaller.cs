using _Project.Codebase.Modules.Player;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Installers
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private PlayerAttackHandler attackHandler;
        [SerializeField] private EnemyObserver enemyObserver;
        public override void InstallBindings()
        {
            Container.Bind<CharacterController>().FromInstance(characterController).AsSingle();
            Container.Bind<PlayerAttackHandler>().FromInstance(attackHandler).AsSingle();
            Container.Bind<EnemyObserver>().FromInstance(enemyObserver).AsSingle();
        }
    }
}