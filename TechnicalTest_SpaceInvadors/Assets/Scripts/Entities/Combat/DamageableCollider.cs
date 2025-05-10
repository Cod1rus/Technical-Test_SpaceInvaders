using UnityEngine;

namespace Entities.Combat
{
    public class DamageableCollider : MonoBehaviour
    {
        private Collider _collider;
        private EntityBase _parentEntity;
        
        private void Awake()
        {
            _parentEntity = GetComponentInParent<EntityBase>();
        }

        public void TakeDamage(float damage, bool percentageBased = false)
        {
            if (_parentEntity) _parentEntity.Health.TakeDamage(damage);
        }
    }
}