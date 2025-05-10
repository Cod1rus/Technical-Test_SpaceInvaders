using System;
using UnityEngine;

namespace Utils
{
    [DefaultExecutionOrder(-1000)]
    public class SingletonBehaviour<T> : MonoBehaviour
        where T : Component
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    try
                    {
                        var objs = FindObjectsByType<T>(FindObjectsSortMode.None);
                        if (objs.Length > 0)
                            _instance = objs[0];
                        if (objs.Length > 1)
                        {
                            Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                        }
                        if (_instance == null)
                        {
                            var obj = new GameObject();
                            obj.name = $"_{typeof(T).Name}";
                            _instance = obj.AddComponent<T>();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    
                }
                return _instance;
            }
        }
    }
}