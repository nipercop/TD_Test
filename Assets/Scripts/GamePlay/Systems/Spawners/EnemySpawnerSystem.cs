using System;
using System.Collections.Generic;
using Game.GamePlayCore.Interfaces.Systems.Spawners;
using Game.GamePlayCore.Units;
using UnityEngine;
using VContainer;

namespace Game.GamePlayCore.Systems.Spawners
{
    public class EnemySpawnerSystem : MonoBehaviour ,  ISpawnerSystem
    {
        private List<DamagableUnit> _units = new List<DamagableUnit>();
        
        void Start()
        {
        }

        private void OnDestroy()
        {
        }

        public void Spawn(GameObject unitPrefab, Vector3 position, Vector3 destination)
        {
            
        }
    }
}
