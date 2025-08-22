using UnityEngine;
using Unity.Entities;

namespace Game.ECS.Data
{
    public struct EnemyData : IComponentData
    {
        public int Health;
    }
}