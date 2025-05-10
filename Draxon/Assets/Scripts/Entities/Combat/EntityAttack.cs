using UnityEngine;

namespace Entities.Combat
{
    public class EntityAttack : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        public void Attack(float damage)
        {
            var projectile = Instantiate(_projectile);
            Destroy(projectile, 10f);
        }
    }
}