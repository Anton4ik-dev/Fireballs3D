using UnityEngine;

namespace Player
{
    public class ShootingInput : MonoBehaviour
    {
        private Shooting _shooting;
        private float _reloadTime;
        public void Initialize(Shooting shooting)
        {
            _shooting = shooting;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _reloadTime <= 0)
            {
                _shooting.Shoot();
            }
            _reloadTime -= Time.deltaTime;
        }
        public void SetReloadTime(float time)
        {
            _reloadTime = time;
        }
    }
}