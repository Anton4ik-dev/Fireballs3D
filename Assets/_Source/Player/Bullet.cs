using ScriptableObjects;
using UnityEngine;

namespace Player
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private BulletSO bulletSO;

        private void Start() => rb.AddForce(rb.transform.forward * bulletSO.BulletSpeed);
    }
}