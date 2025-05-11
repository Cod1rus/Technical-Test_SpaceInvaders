using UnityEngine;

namespace Entities
{
    public class EnemyController : EntityController
    {
        private EntityBase _entityBase;
        private float _lastAttackTime;
        
        private void Awake()
        {
            _entityBase = GetComponent<EntityBase>();

            _entityBase.Health.Die += Die;
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