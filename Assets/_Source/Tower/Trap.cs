using Observer;
using ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem
{
    class Trap : MonoBehaviour, IObservable
    {
        [SerializeField] private LayerMask bulletLayer;
        [SerializeField] private PancakeSO _pancake;
        [SerializeField] private List<GameObject> _gameObjectPancakes;
        private List<IObserver> _observers;
        private int _bulletLayerNumber;
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
                _observers[i].Update(_pancake.Cost);
            }
        }
        private void Start()
        {
            _observers = new List<IObserver>();
            _bulletLayerNumber = (int)Mathf.Log(bulletLayer.value, 2);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _bulletLayerNumber)
            {
                Destroy(other.gameObject);
                //Destroy();
                NotifyObservers();
            }
        }
    }
}