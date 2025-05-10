using Manager;
using UnityEngine;

namespace Entities
{
    public class MovementController : MonoBehaviour
    {
        private EntityBase _entityBase;
        
        private float _moveSpeed;
        private Vector2 _movementDirection;
        
        private void Awake()
        {
            var entityBase = GetComponent<EntityBase>();
            _moveSpeed = entityBase.Config.MoveSpeed;
        }

        private void Move(Vector2 move)
        {
            var currentPosition = transform.position;
            var newPosition = new Vector3(
                currentPosition.x + move.x * _moveSpeed * Time.deltaTime,
                currentPosition.y,
                currentPosition.z + move.y * _moveSpeed * Time.deltaTime);

            if (!LevelManager.Instance.LevelBounds.IsInBounds(newPosition)) return;
            
            transform.position = newPosition;
        }
        
        public void SetMovementDirection(Vector2 direction)
        {
            _movementDirection = direction;
        }

        private void Update()
        {
            if (_movementDirection != Vector2.zero)
                Move(_movementDirection);
        }
    }
}