using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Entities.Combat
{
    public class EntityAttack : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;

        private ObjectPool<Projectile> _projectilePool;

        private void Awake()
        {
            _projectilePool = new ObjectPool<Projectile>(CreateProjectile, GetProjectile, ReturnedToPool, DestroyPoolObject);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
            _projectilePool.Dispose();
        }

        public void Attack(float damage)
        {
            var projectile = _projectilePool.Get();
            projectile.Damage = damage;
            StartCoroutine(WaitForDespawn());
            return;
            IEnumerator WaitForDespawn()
            {
                yield return new WaitForSeconds(3f);
                _projectilePool.Release(projectile);
            }
        }

        private Projectile CreateProjectile()
        {
            var projectile = Instantiate(_projectile);
            projectile.transform.position = transform.position + transform.forward * 1.5f;
            projectile.transform.rotation = transform.rotation;

            return projectile;
        }
        
        private void GetProjectile(Projectile obj)
        {
            obj.gameObject.SetActive(true);
            
            obj.transform.position = transform.position + transform.forward * 1.5f;
            obj.transform.rotation = transform.rotation;
        }
        
        private void ReturnedToPool(Projectile obj)
        {
            obj.gameObject.SetActive(false);
        }
        
        private void DestroyPoolObject(Projectile obj)
        {
            Destroy(obj);
        }
    }
}