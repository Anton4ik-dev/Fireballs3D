using ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Static
{
    public static class RandomSort
    {
        public static void Sort(ref List<PancakeSO> pancakes)
        {
            for (int i = 0; i < pancakes.Count; i++)
            {
                int j = Random.Range(0, pancakes.Count - 1);
                PancakeSO element = pancakes[i];
                pancakes[i] = pancakes[j];
                pancakes[j] = element;
            }
        }
    }
}