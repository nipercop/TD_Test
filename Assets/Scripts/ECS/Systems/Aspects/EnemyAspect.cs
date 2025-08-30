using Game.ECS.Data.Damage;
using Game.ECS.Data.Move;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.ECS.Aspects
{
    
    public readonly partial struct EnemyAspect : IAspect
    {
        private readonly RefRO<MoveToTargetData> MoveToTargetData;
        private readonly RefRO<MoveSpeedData> MoveSpeedData;
        public readonly RefRW<LocalTransform> TransformData;
        private readonly RefRO<DamageData> DamageData;
        private readonly RefRW<MovePathData> MovePathData;
        
        public Entity Target => MoveToTargetData.ValueRO.Target;
        public int Damage => DamageData.ValueRO.Value;
        public float MoveSpeed => MoveSpeedData.ValueRO.Value;
        public float MoveSpeedMultiplier => MoveSpeedData.ValueRO.Multiplicator;
        public BlobAssetReference<WaypointsData> Path => MovePathData.ValueRO.Path;
        public int WaypointIndex => MovePathData.ValueRO.CurrentWaypoint;
        public float3 Position => TransformData.ValueRO.Position;

        public void IncreateWaypointIndex()
        {
            MovePathData.ValueRW.CurrentWaypoint++;
        }

    }

}