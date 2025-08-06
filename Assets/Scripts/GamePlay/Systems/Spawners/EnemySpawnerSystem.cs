using Game.GamePlayCore.Interfaces.Systems.Spawners;
using Game.GamePlayCore.Systems.Spawners.Data;
using Game.GamePlayCore.Units;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace Game.GamePlayCore.Systems.Spawners
{
    public class EnemySpawnerSystem:  ISpawnerSystem
    {

        private readonly IObjectResolver _resolver;

        [Inject]
        public EnemySpawnerSystem(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        public void Spawn(SpawnData spawnData)
        {
            for (int i = 0; i < spawnData.CountSpawn; i++)
            {
                var newPos = GetRandomedPosition(spawnData.Position);
                var unit = Object.Instantiate(spawnData.Prefab, newPos, Quaternion.identity); 
                _resolver.Inject(unit);
                unit.GetComponent<DamagableUnit>().SetSpawnData(spawnData);
            }
        }

        private Vector3 GetRandomedPosition(Vector3 originalPosition)
        {
            var randomedPosition = UnityEngine.Random.insideUnitCircle * 2;
            return originalPosition + new Vector3(randomedPosition.x, 0, randomedPosition.y);
        }
    }
}
