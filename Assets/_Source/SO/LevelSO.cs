using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelSO", menuName = "ScriptableObjects/LevelSO", order = 1)]
    public class LevelSO : ScriptableObject
    {
        public List<PartOfTowerInfo> Pancakes;
        public PancakeSO ObstacleSO;
    }
}