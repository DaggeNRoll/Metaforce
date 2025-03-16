using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Enemy
{
    public class Enemy : MonoBehaviour
    {
        
        public class Factory : PlaceholderFactory<Enemy>{}
    }
}