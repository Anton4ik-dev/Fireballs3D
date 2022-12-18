using Observer;
using ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem
{
    class Tower : MonoBehaviour, IObservable
    {
        [SerializeField] private LayerMask bulletLayer;
        private List<PancakeSO> _pancakes;
        private List<GameObject> _gameObjectPancakes;
        private List<IObserver> _observers;
        private int _bulletLayerNumber;
        private Vector3 _decreasingVector;
        private void DecreaseTower()
        {
            Destroy(_gameObjectPancakes[0]);
            _gameObjectPancakes.RemoveAt(0);
            for (int i = 0; i < _gameObjectPancakes.Count; i++)
            {
                _gameObjectPancakes[i].transform.position -= _decreasingVector;
            }
            if(_gameObjectPancakes.Count == 0)
            {
                //win
            }
        }
        public void TowerInitialize(List<PancakeSO> pancakes, List<GameObject> gameObjectPancakes)
        {
            _observers = new List<IObserver>();
            _pancakes = pancakes;
            _gameObjectPancakes = gameObjectPancakes;
            _decreasingVector = new Vector3(0, _gameObjectPancakes[0].transform.localScale.y, 0);
            _bulletLayerNumber = (int)Mathf.Log(bulletLayer.value, 2);
        }
        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].Update(_pancakes[0].Cost);
                _pancakes.RemoveAt(0);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _bulletLayerNumber)
            {
                Destroy(other.gameObject);
                DecreaseTower();
                NotifyObservers();
            }
        }
    }
}