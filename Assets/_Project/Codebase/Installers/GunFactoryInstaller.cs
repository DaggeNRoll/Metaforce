using _Project.Codebase.Modules.Player.Guns;
using Zenject;

namespace _Project.Codebase.Installers
{
    public class GunFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Pistol>().AsSingle().NonLazy();
            Container.Bind<Grenade>().AsSingle().NonLazy();
            Container.Bind<GunFactory>().AsSingle().NonLazy();
        }
    }
}