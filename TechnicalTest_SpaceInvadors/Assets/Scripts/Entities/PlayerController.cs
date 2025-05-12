using UnityEngine;
using Utils;

namespace Entities
{
    public class PlayerController : EntityController
    {
        private Player _player;
        private ComponentsHandler _componentsHandler;
        private MovementController _movement;

        private float _lastAttackTime;
        
        private void Start()
        {
            _componentsHandler = GetComponent<ComponentsHandler>();
            _movement = _componentsHandler.Get<MovementController>();

            _player = _componentsHandler.Get<Player>();
            
            _player.InputReader.Move += MoveInput;
            _player.InputReader.MoveCancelled += StopMoving;

            _player.InputReader.Shoot += Attack;

            _player.Health.Die += Die;
        }
        
        private void OnDestroy()
        {
            if (_player.InputReader)
            {
                _player.InputReader.Move -= MoveInput;
                _player.InputReader.MoveCancelled -= StopMoving;

                _player.InputReader.Shoot -= Attack;
                
                _player.Health.Die -= Die;
            }
        }

        private void Attack()
        {
            if (_lastAttackTime + _player.Config.AttackDelay > Time.time) return;
            
            _lastAttackTime = Time.time;
            _player.EntityAttack.Attack(_player.Config.Damage);
        }
        
        private void MoveInput(Vector2 move)
        {
            _movement.SetMovementDirection(new Vector2(move.x, 0));
        }

        private void StopMoving()
        {
            _movement.SetMovementDirection(Vector2.zero);
        }

        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}