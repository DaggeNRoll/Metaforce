using _Project.Codebase.Modules.Conifguration;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Installers
{
    public class ConfigurationInstaller : MonoInstaller
    {
        [SerializeField] private ProjectConfiguration projectConfiguration;

        public override void InstallBindings()
        {
            Container.Bind<ConfigurationService>().AsSingle().WithArguments(projectConfiguration.Configs);
        }
    }
}