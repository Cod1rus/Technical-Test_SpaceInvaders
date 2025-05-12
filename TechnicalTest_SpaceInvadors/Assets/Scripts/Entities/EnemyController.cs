using UnityEngine;
using Utils;

namespace Entities
{
    public class EnemyController : EntityController
    {
        private EntityBase _entityBase;
        private ComponentsHandler _componentsHandler;
        
        private float _lastAttackTime;
        
        private MovementController _movement;
        
        private void Start()
        {
            _componentsHandler = GetComponent<ComponentsHandler>();
            _movement = _componentsHandler.Get<MovementController>();
            _entityBase = _componentsHandler.Get<Enemy>();

            _entityBase.Health.Die += Die;
            
            _movement.SetMovementDirection(new Vector2(0, -1));
        }

        private void FixedUpdate()
        {
            Attack();
        }


        private void Attack()
        {
            if (_lastAttackTime + _entityBase.Config.AttackDelay > Time.time) return;
            _lastAttackTime = Time.time;
            _entityBase.EntityAttack.Attack(_entityBase.Config.Damage);
        }
    }
}