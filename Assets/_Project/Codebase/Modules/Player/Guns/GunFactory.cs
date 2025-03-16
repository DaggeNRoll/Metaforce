using Zenject;

namespace _Project.Codebase.Modules.Player.Guns
{
    public class GunFactory
    {
        private DiContainer _container;

        [Inject]
        public GunFactory(DiContainer container)
        {
            _container = container;
        }

        public T CreateGun<T>() where T : class, IGun
        {
            return _container.Resolve<T>();
        }
    }
}