using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChargeSO", menuName = "ScriptableObjects/ChargeSO", order = 1)]
    public class ChargeSO : ScriptableObject
    {
        public int shootCost;
        public int maxCharge;
        public float reloadTime;
    }
}