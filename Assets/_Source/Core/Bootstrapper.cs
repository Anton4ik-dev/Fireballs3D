using MV;
using Observer;
using Player;
using ScriptableObjects;
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
        private IObservable trapObservable;

        private void Awake()
        {
            shootingInput.Initialize(new Shooting(shootSpot, bulletSO.BulletPrefab));

            _towerSpawner = new TowerSpawner(levelSos, tower);
            trapObservable = _towerSpawner.SpawnTower();

            new UIModel(tower, uiView);
        }
    }
}