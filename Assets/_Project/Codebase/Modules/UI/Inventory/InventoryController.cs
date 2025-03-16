using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.UI.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        private IInputHandler _inputHandler;

        [Inject]
        public void Construct(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private void Initialize()
        {
            _inputHandler.WeaponChanged += OnChangeWeapon;
        }

        private void OnChangeWeapon()
        {
            
        }
    }
}