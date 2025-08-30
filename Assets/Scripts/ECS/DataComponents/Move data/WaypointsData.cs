using Unity.Entities;
using Unity.Mathematics;

namespace Game.ECS.Data.Move
{
    public struct WaypointsData : IComponentData
    {
        public BlobArray<float3> Waypoints;
    }
}