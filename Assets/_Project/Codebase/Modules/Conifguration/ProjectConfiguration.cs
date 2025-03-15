using System.Collections.Generic;
using UnityEngine;

namespace _Project.Codebase.Modules.Conifguration
{
    [CreateAssetMenu(fileName = "Project Configuration", menuName = "Configs/Project", order = 0)]
    public class ProjectConfiguration : ScriptableObject
    {
        [SerializeField] private List<Configuration> configs;
        
        public IReadOnlyList<Configuration> Configs => configs;
    }
}