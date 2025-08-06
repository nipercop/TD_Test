using Game.GamePlayCore.Systems.Spawners.Data;
using UnityEngine;

namespace Game.GamePlayCore.Interfaces.Systems.Spawners
{
    public interface ISpawnerSystem
    {
        void Spawn(SpawnData spawnData);
    }
}
