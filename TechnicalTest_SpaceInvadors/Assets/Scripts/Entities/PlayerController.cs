using UnityEngine;
using Utils;

namespace Entities
{
    public class PlayerController : MonoBehaviour
    {
        private Player _player;
        private ComponentsHandler _componentsHandler;
        private MovementController _movement;
        
        private void Start()
        {
            _componentsHandler = GetComponent<ComponentsHandler>();
            _movement = _componentsHandler.Get<MovementController>();

            _player = _componentsHandler.Get<Player>();
            
            _player.InputReader.Move += MoveInput;
            _player.InputReader.MoveCancelled += StopMoving;
        }
        
        private void MoveInput(Vector2 move)
        {
            _movement.SetMovementDirection(new Vector2(move.x, 0));
        }

        private void StopMoving()
        {
            _movement.SetMovementDirection(Vector2.zero);
        }
    }
}