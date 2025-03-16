using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Codebase.Modules
{
    public interface IInputHandler
    {
        InputAction MoveAction { get; }
        InputAction ChangeWeaponAction { get; }
        Vector2 MoveValue { get; }
        event Action WeaponChanged;
    }

    [UsedImplicitly]
    public class DesktopInputHandler : IInputHandler, IDisposable, IInitializable, ITickable
    {
        public InputAction MoveAction { get; private set; }
        public InputAction ChangeWeaponAction { get; private set; }
        public Vector2 MoveValue { get; private set; }
        public event Action WeaponChanged;

        public void Dispose()
        {
            
        }

        public void Initialize()
        {
            MoveAction = InputSystem.actions.FindAction("Move");
            ChangeWeaponAction = InputSystem.actions.FindAction("Change Weapon");
        }

        public void Tick()
        {
            MoveValue = MoveAction.ReadValue<Vector2>().normalized;
        }
    }
}