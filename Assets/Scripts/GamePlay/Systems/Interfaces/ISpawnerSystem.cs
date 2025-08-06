using UnityEngine;

namespace Game.GamePlayCore.Interfaces.Systems.Spawners
{
    public interface ISpawnerSystem
    {
        void Spawn(GameObject unitPrefab, Vector3 position, Vector3 destination);
    }
}
