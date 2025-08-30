using Unity.Entities;
using UnityEngine;

namespace Game.ECS.Data
{
    public struct TowerData : IComponentData
    {
        public float Range;
        public float AttackTime;
        public int Damage;
        public Entity ProjectilePrefab;
    }

    public class TowerVisual : IComponentData
    {
        public Animator Animator;
    }
}