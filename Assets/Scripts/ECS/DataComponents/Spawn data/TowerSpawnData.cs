using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Game.ECS.Data.Spawn
{
    public struct TowerSpawnData : IComponentData
    {
        public Entity TowerPrefab;
        public float Range;
        public float AttackTime;
        public int Damage;
        public Entity ProjectilePrefab;
        public int Health;
        public float3 Position;
    }
}