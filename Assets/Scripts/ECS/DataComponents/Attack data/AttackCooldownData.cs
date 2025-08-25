using Unity.Entities;
using UnityEngine;

namespace Game.ECS.Data
{
    public struct AttackCooldownData : IComponentData
    {
        public float Value;
        public float Multiplier;
    }
}