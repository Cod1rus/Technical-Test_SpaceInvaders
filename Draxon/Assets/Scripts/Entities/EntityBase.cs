using Entities.Combat;
using Unity.VisualScripting;
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
        
        protected virtual void Start()
        {
            ComponentsHandler = GetComponent<ComponentsHandler>();
            ComponentsHandler.FindReferences();
            
            Health.Init(_config.Health);
        }
    }
}