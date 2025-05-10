using UnityEngine;

namespace Entities.Combat
{
    [CreateAssetMenu(menuName = "Configs/ProjectileConfig")]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;
    }
}