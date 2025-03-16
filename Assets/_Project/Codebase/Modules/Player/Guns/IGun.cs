using UnityEngine;

namespace _Project.Codebase.Modules.Player.Guns
{
    public interface IGun
    {
        void Shoot(Vector3 direction, Vector3 shootPoint);
    }
}