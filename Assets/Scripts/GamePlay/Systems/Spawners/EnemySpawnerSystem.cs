using System;
using System.Collections.Generic;
using Game.GamePlayCore.Interfaces.Systems.Spawners;
using Game.GamePlayCore.Systems.Spawners.Data;
using Game.GamePlayCore.Units;
using UnityEngine;
using VContainer;

namespace Game.GamePlayCore.Systems.Spawners
{
    public class EnemySpawnerSystem : MonoBehaviour ,  ISpawnerSystem
    {
        private List<DamagableUnit> _units = new List<DamagableUnit>(); 
        
        public void Spawn(SpawnData spawnData)
        {
            for (int i = 0; i < spawnData.CountSpawn; i++)
            {
                var newPos = GetRandomedPosition(spawnData.Position);
                var unit = Instantiate(spawnData.Prefab, newPos, Quaternion.identity).GetComponent<DamagableUnit>();
                unit.SetSpawnData(spawnData);
                _units.Add(unit);
            }
        }

        private Vector3 GetRandomedPosition(Vector3 originalPosition)
        {
            var randomedPosition = UnityEngine.Random.insideUnitCircle * 2;
            return originalPosition + new Vector3(randomedPosition.x, 0, randomedPosition.y);
        }
    }
}
