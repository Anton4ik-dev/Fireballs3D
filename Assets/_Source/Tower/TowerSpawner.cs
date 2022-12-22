using ScriptableObjects;
using StateSystem;
using Static;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem
{
    class TowerSpawner
    {
        private LevelSO _levelSO;
        private Tower _tower;
        public TowerSpawner(List<LevelSO> levelSOs, Tower tower)
        {
            int rnd = Random.Range(0, levelSOs.Count - 1);
            _levelSO = levelSOs[rnd];
            _tower = tower;
        }
        private List<PancakeSO> FillPancakeList()
        {
            List<PancakeSO> pancakes = new List<PancakeSO>();

            for (int i = 0; i < _levelSO.Pancakes.Count; i++)
            {
                for (int z = 0; z < _levelSO.Pancakes[i].AmountOFPancakes; z++)
                {
                    pancakes.Add(_levelSO.Pancakes[i].PancakeSO);
                }
            }

            RandomSort.Sort(ref pancakes);
            return pancakes;
        }
        private List<GameObject> PancakesInstantiate(List<PancakeSO> pancakes)
        {
            List<GameObject> gameObjectPancakes = new List<GameObject>();
            Vector3 pos = _tower.transform.position;
            float yAdd = pancakes[0].PancakePrefab.transform.localScale.y / 2;
            for (int i = 0; i < pancakes.Count; i++)
            {
                pos.y += yAdd;
                gameObjectPancakes.Add(GameObject.Instantiate(pancakes[i].PancakePrefab, _tower.transform));
                gameObjectPancakes[i].transform.position = pos;
                pos.y += yAdd;
            }
            return gameObjectPancakes;
        }
        public void SpawnTower(GameStateMachine gameStateMachine)
        {
            List<PancakeSO> pancakes = FillPancakeList();
            List<GameObject> gameObjectPancakes = PancakesInstantiate(pancakes);

            _tower.TowerInitialize(pancakes, gameObjectPancakes, gameStateMachine);
            
            GameObject.Instantiate(_levelSO.ObstaclePrefab, _tower.transform.position, Quaternion.identity);
        }
    }
}