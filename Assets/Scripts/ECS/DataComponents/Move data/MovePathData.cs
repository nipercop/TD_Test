using Unity.Entities;
using Unity.Mathematics;

namespace Game.ECS.Data.Move
{
    public struct MovePathData : IComponentData
    {
        public BlobAssetReference<WaypointsData> Path;
        public int CurrentWaypoint;
    }
}