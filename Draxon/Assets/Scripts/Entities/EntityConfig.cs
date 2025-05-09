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
        
        [SerializeField] private float _damage;
        public float Damage => _damage;
    }
}