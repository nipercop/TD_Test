using Game.ECS.Data.Damage;
using Game.ECS.Data.Move;
using Unity.Entities;
using Unity.Transforms;

namespace Game.ECS.Aspects
{
    
    public readonly partial struct EnemyAspect : IAspect
    {
        private readonly RefRO<MoveToTargetData> MoveToTargetData;
        private readonly RefRW<MoveSpeedData> MoveSpeedData;
        public readonly RefRW<LocalTransform> TransformData;
        private readonly RefRO<DamageData> DamageData;
        
        public Entity Target => MoveToTargetData.ValueRO.Target;
        public int Damage => DamageData.ValueRO.Value;
        public float MoveSpeed => MoveSpeedData.ValueRW.Value;
        public float MoveSpeedMultiplier => MoveSpeedData.ValueRW.Multiplicator;

    }

}