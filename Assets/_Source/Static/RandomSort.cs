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
                int rnd = Random.Range(0, pancakes.Count);
                PancakeSO element = pancakes[i];
                pancakes[i] = pancakes[rnd];
                pancakes[rnd] = element;
            }
        }
    }
}