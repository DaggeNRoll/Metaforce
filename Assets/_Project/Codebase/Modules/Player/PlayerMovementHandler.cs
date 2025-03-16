using System;
using _Project.Codebase.Modules.Conifguration;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Player
{
    public class PlayerMovementHandler : MonoBehaviour
    {
        private IInputHandler _inputHandler;
        private ConfigurationService _configurationService;
        private CharacterController _characterController;
        private float _speed;
        
        [Inject]
        public void Construct(IInputHandler inputHandler, ConfigurationService configurationService, CharacterController characterController)
        {
            _inputHandler = inputHandler;
            _configurationService = configurationService;
            _characterController = characterController;
        }

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            _characterController
                .SimpleMove(new Vector3(_inputHandler.MoveValue.x, 0f, _inputHandler.MoveValue.y) * _speed);
        }

        private void Initialize()
        {
            _speed = _configurationService.GetConfiguration<PlayerConfiguration>().MovementSpeed;
        }
    }
    
}