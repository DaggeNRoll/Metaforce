using System;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Player
{
    public class PlayerMovementHandler : MonoBehaviour
    {
        private IInputHandler _inputHandler;
        private CharacterController _characterController;
        private float _speed = 5f;
        
        [Inject]
        public void Construct(IInputHandler inputHandler, CharacterController characterController)
        {
            _inputHandler = inputHandler;
            _characterController = characterController;
        }

        private void Update()
        {
            _characterController
                .SimpleMove(new Vector3(_inputHandler.MoveValue.x, 0f, _inputHandler.MoveValue.y) * _speed);
        }
    }
    
}