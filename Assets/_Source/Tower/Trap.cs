using MV;
using ScriptableObjects;
using UnityEngine;

namespace TowerSystem
{
    class Trap : MonoBehaviour
    {
        [SerializeField] private Transform rotatePoint;
        [SerializeField] private TrapSO trapSO;

        private int _bulletLayerNumber;

        private void Start() => _bulletLayerNumber = (int)Mathf.Log(trapSO.BulletLayer.value, 2);

        private void Update() => transform.RotateAround(rotatePoint.position, Vector3.up, trapSO.RotateSpeed * Time.deltaTime);

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _bulletLayerNumber)
            {
                Destroy(other.gameObject);
                Score.OnScoreChange?.Invoke(trapSO.Cost);
                Destroy(gameObject);
            }
        }
    }
}