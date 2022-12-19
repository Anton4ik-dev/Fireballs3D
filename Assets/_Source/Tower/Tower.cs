using MV;
using Observer;
using ScriptableObjects;
using StateSystem;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem
{
    class Tower : MonoBehaviour
    {
        [SerializeField] private LayerMask bulletLayer;
        private List<PancakeSO> _pancakes;
        private List<GameObject> _gameObjectPancakes;
        private GameStateMachine _gameStateMachine;
        private Vector3 _decreasingVector;
        private int _bulletLayerNumber;
        private void DecreaseTower()
        {
            Destroy(_gameObjectPancakes[0]);
            _gameObjectPancakes.RemoveAt(0);
            _pancakes.RemoveAt(0);
            transform.position -= _decreasingVector;
        }
        private void CheckWin()
        {
            if (_gameObjectPancakes.Count == 0)
            {
                _gameStateMachine.ChangeState(typeof(Win));
            }
        }
        public void TowerInitialize(List<PancakeSO> pancakes, List<GameObject> gameObjectPancakes, GameStateMachine gameStateMachine)
        {
            _pancakes = pancakes;
            _gameObjectPancakes = gameObjectPancakes;
            _decreasingVector = new Vector3(0, _gameObjectPancakes[0].transform.localScale.y, 0);
            _bulletLayerNumber = (int)Mathf.Log(bulletLayer.value, 2);
            _gameStateMachine = gameStateMachine;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _bulletLayerNumber)
            {
                Destroy(other.gameObject);
                ScoreChangeDetector.OnScoreChange?.Invoke(_pancakes[0].Cost);
                DecreaseTower();
                CheckWin();
            }
        }
    }
}