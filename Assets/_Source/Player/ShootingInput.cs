using UnityEngine;

namespace Player
{
    public class ShootingInput : MonoBehaviour
    {
        private Shooting _shooting;
        public void Initialize(Shooting shooting)
        {
            _shooting = shooting;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _shooting.Shoot();
            }
        }
    }
}