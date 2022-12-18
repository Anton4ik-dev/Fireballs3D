using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletSO", menuName = "ScriptableObjects/BulletSO", order = 1)]
    public class BulletSO : ScriptableObject
    {
        public float BulletSpeed;
        public GameObject BulletPrefab;
    }
}