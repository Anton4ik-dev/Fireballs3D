using MV;
using Observer;
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

        [Header("Tower")]
        [SerializeField] private Tower tower;
        [SerializeField] private List<LevelSO> levelSos;

        [Header("UIView")]
        [SerializeField] private UIView uiView;

        private TowerSpawner _towerSpawner;
        private ScoreChangeDetector _scoreDetector;
        private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            _gameStateMachine = new GameStateMachine();
            _towerSpawner = new TowerSpawner(levelSos, tower);
            _scoreDetector = new ScoreChangeDetector();
            new UIModel(_scoreDetector, _gameStateMachine, uiView);

            shootingInput.Initialize(new Shooting(shootSpot, bulletSO.BulletPrefab));
            _towerSpawner.SpawnTower(_gameStateMachine);

            _gameStateMachine.StartState(typeof(Game));
        }
    }
}