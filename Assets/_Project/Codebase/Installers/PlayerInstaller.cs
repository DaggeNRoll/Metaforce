using UnityEngine;
using Zenject;

namespace _Project.Codebase.Installers
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        [SerializeField] private CharacterController characterController;
        public override void InstallBindings()
        {
            Container.Bind<CharacterController>().FromInstance(characterController).AsSingle();
        }
    }
}