using MV;
using Player;
using ScriptableObjects;
using StateSystem;
using System.Collections.Generic;
using TowerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [Header("Shooting")]
        [SerializeField] private ShootingInput shootingInput;
        [SerializeField] private Transform shootSpot;
        [SerializeField] private BulletSO bulletSO;
        [SerializeField] private ChargeSO chargeSO;

        [Header("Tower")]
        [SerializeField] private Tower tower;
        [SerializeField] private List<LevelSO> levelSos;

        [Header("UIView")]
        [SerializeField] private ScoreAndChargeView _scoreAndChargeView;
        
        private TowerSpawner _towerSpawner;
        private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            _gameStateMachine = new GameStateMachine();
            new StateInitializer(_gameStateMachine);

            _towerSpawner = new TowerSpawner(levelSos, tower);

            new Score(_scoreAndChargeView);
            new Charge(_scoreAndChargeView, chargeSO, shootingInput);

            shootingInput.Initialize(new Shooting(shootSpot, bulletSO.BulletPrefab));
            _towerSpawner.SpawnTower(_gameStateMachine);

            _gameStateMachine.StartState(typeof(Game));
        }
    }
}