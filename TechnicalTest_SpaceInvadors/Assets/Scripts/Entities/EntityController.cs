using UnityEngine;

namespace Entities
{
    public class EntityController : MonoBehaviour
    {
        protected virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}