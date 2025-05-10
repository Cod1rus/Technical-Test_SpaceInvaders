using Entities;
using Utils;

namespace Manager
{
    public class LevelManager : SingletonBehaviour<LevelManager>
    {
        public LevelBounds LevelBounds => _components.Get<LevelBounds>();

        private ComponentsHandler _components;
        
        private void Awake()
        {
            _components = GetComponent<ComponentsHandler>();
        }
    }
}