using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TrapSo", menuName = "ScriptableObjects/TrapSo", order = 1)]
    public class TrapSO : ScriptableObject
    {
        public int Cost;
        public float RotateSpeed;
        public LayerMask BulletLayer;
    }
}