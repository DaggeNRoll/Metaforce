using UnityEngine;

namespace _Project.Codebase.Modules.Player.Guns
{
    public abstract class GunBase
    {
        protected int _clipSize;
        protected int _damageRate;
        protected Transform _muzzlePoint;

        protected GunBase(int clipSize, int damageRate, Transform muzzlePoint)
        {
            _clipSize = clipSize;
            _damageRate = damageRate;
            _muzzlePoint = muzzlePoint;
        }

        public abstract void Shoot(Vector3 direction);
    }
}