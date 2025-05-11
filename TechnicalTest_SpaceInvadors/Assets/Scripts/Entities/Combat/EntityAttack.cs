using UnityEngine;

namespace Entities.Combat
{
    public class EntityAttack : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        
        public void Attack(float damage)
        {
            var projectile = Instantiate(_projectile);
            projectile.Damage = damage;
            
            projectile.transform.position = transform.position + transform.forward * 1.5f;
            projectile.transform.rotation = transform.rotation;
            
            Destroy(projectile.gameObject, 3f);
        }
    }
}