using UnityEngine;

namespace Player
{
    public class Shooting
    {
        private Transform _shootSpot;
        private GameObject _bulletPrefab;
        public Shooting(Transform shootSpot, GameObject bulletPrefab)
        {
            _shootSpot = shootSpot;
            _bulletPrefab = bulletPrefab;
        }
        public void Shoot()
        {
            GameObject.Instantiate(_bulletPrefab, _shootSpot.position, Quaternion.identity);
        }
    }
}