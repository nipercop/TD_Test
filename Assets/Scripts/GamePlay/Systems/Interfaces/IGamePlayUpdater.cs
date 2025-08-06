using UnityEngine;

namespace  Game.GamePlayCore.Interfaces.Systems
{
    public interface IGamePlayUpdater
    {

        void AddUpdatable(IUpdatable updatable);

        void RemoveUpdatable(IUpdatable updatable);
    }
}
