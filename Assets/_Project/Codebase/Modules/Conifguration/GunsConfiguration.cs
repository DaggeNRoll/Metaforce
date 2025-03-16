using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Codebase.Modules.Conifguration
{
    [CreateAssetMenu(menuName = "Configs/Guns", fileName = "GunsConfiguration", order = 0)]
    public class GunsConfiguration : Configuration
    {
        [SerializeField]
        private List<GunConfig> gunConfigurations;
        public IReadOnlyList<GunConfig> GunConfigs => gunConfigurations.AsReadOnly();
    }

    [Serializable]
    public class GunConfig
    {
        [field: SerializeField]
        public GunType GunType { get; private set; }
        [field: SerializeField]
        public int ClipSize { get; private set; }
        [field: SerializeField]
        public int Damage { get; private set; }
        [field: SerializeField]
        public float FireRate { get; private set; }
    }

    public enum GunType
    {
        Pistol,
        Grenade
    }
}