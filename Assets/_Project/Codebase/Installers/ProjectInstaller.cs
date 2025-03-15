using _Project.Codebase.Modules;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DesktopInputHandler>().AsSingle().NonLazy();
        }
    }
}