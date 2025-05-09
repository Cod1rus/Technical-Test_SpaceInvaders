using Entities.Combat;
using UnityEngine;
using Utils;

namespace Entities
{
    public abstract class EntityBase : MonoBehaviour
    {
        public ComponentsHandler ComponentsHandler { get; private set; }
        public Health Health => ComponentsHandler.Get<Health>();

        [SerializeField] private EntityConfig _config;
        public EntityConfig Config => _config;
        
        private void Awake()
        {
            ComponentsHandler = GetComponent<ComponentsHandler>();
            Health.Init(_config.Health);
        }
    }
}