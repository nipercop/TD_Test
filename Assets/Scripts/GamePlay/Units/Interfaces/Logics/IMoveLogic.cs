using UnityEngine;

namespace Game.GamePlayCore.Interfaces.Units.Logic.Move
{
    public interface IMoveLogic 
    {
        void DoUpdate(float deltaTime);
        void SetDestination(Vector3 destination);
    }
}
