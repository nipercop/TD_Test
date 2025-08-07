using Game.GamePlayCore.Stats;
using Game.GamePlayCore.Units;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.GamePlayCore.Systems.Spawners.Data
{
    public class SpawnData
    {
        public int CountSpawn;
        public GameObject Prefab;
        public Vector3 Position;
        public DamagableUnit Destination;
        public StatsUnit NewStats;
    }
}
