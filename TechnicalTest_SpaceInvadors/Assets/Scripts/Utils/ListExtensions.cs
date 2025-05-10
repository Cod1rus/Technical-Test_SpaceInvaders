using System.Collections.Generic;

namespace Utils
{
    public static class ListExtensions
    {
        public static T GetRandom<T>(this List<T> source)
        {
            return source[UnityEngine.Random.Range(0, source.Count)];
        }
    }
}