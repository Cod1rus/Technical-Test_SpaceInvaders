using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(menuName = "Configs/Entities")]
    public class EntityConfig : ScriptableObject
    {
        [SerializeField] private float _health;
        public float Health => _health;
        
        [SerializeField] private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;
        
        [Header("Combat")]
        [SerializeField] private float _damage;
        public float Damage => _damage;

        [SerializeField] private float _attackDelay;
        public float AttackDelay => _attackDelay;
    }
}