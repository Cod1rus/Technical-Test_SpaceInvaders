using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{    
    [CreateAssetMenu(menuName = "Technical Test/InputReader", fileName = "InputReader")]
    public class InputReader : ScriptableObject, PlayerInput.IGameplayActions
    {
        private PlayerInput _gameInput;
        
        public event Action<Vector2> Move;
        public event Action MoveCancelled;
        public Vector2 MoveDirection;
        
        public event Action Shoot;
        public event Action Restart;
        
        private void OnEnable()
        {
            if (_gameInput != null) return;
            
            _gameInput = new();
            _gameInput.Gameplay.SetCallbacks(this);
            _gameInput.Gameplay.Enable();
        }

        private void OnDestroy()
        {
            if (_gameInput != null)
            {
                _gameInput.Gameplay.Disable();
                _gameInput.Disable();
            }
        }
        
        
        void PlayerInput.IGameplayActions.OnMove(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    Move?.Invoke(context.ReadValue<Vector2>());
                    MoveDirection = context.ReadValue<Vector2>();
                    break;
                case InputActionPhase.Canceled:
                    MoveCancelled?.Invoke();
                    MoveDirection = Vector2.zero;
                    break;
            }
        }
    }
}