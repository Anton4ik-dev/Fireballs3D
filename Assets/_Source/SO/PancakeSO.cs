using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PancakeSO", menuName = "ScriptableObjects/PancakeSO", order = 1)]
    public class PancakeSO : ScriptableObject
    {
        public GameObject PancakePrefab;
        public int Cost;
    }
}