using UnityEngine;

namespace  Game.GamePlayCore.Interfaces.Systems
{
    public interface IGamePlayUpdater
    {

        void AddMoveable(IUpdatable updatable);

        void RemoveMoveable(IUpdatable updatable);
    }
}
