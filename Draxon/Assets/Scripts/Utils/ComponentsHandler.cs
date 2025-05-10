using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils
{
    [DefaultExecutionOrder(-1000)]
    public class ComponentsHandler : MonoBehaviour
    {
        private Dictionary<Type, MonoBehaviour> _components = new();

        private void Awake() => FindReferences();
        private void OnValidate() => FindReferences();

        
        public T Get<T>() where T : MonoBehaviour
        {
            var comp = _components[typeof(T)];
            if (!comp) return null;
            var compAsT = comp as T;
            return !compAsT ? null : compAsT;
        }

        
        private void FindReferences()
        {
            if (_components != null) _components.Clear();
            else _components = new Dictionary<Type, MonoBehaviour>();
            
            var components = GetComponentsInChildren<MonoBehaviour>().ToList();
            foreach (var component in components)
            {
                var type = component.GetType();
                _components.TryAdd(type, component);
            }
        }
    }
}