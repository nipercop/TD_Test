using Game.GamePlayCore.Stats;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.GamePlayCore.Systems.Spawners.Data
{
    public class SpawnData
    {
        public int CountSpawn;
        public GameObject Prefab;
        public Vector3 Position;
        public Vector3 Destination;
        public StatsUnit NewStats;
    }
}
