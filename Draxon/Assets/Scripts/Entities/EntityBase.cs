using Entities.Combat;
using UnityEngine;
using Utils;

namespace Entities
{
    public abstract class EntityBase : MonoBehaviour
    {
        public ComponentsHandler ComponentsHandler { get; private set; }

        [SerializeField] private Health _health;
        public Health Health => _health; 
        
        [SerializeField] private EntityConfig _config;
        public EntityConfig Config => _config;
        
        protected virtual void Start()
        {
            ComponentsHandler = GetComponent<ComponentsHandler>();
            Health.Init(Config.Health);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            ComponentsHandler = GetComponent<ComponentsHandler>();
            _health = ComponentsHandler.Get<Health>();
        }
#endif
    }
}