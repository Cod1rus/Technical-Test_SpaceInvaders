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
            transform.position = new Vector3(
                transform.position.x + move.x * _moveSpeed * Time.deltaTime,
                transform.position.y,
                transform.position.z + move.y * _moveSpeed * Time.deltaTime);
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