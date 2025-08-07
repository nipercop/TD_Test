using Game.GamePlayCore.Units;
using UnityEngine;

namespace Game.GamePlayCore.Interfaces.Units.Logic.Move
{
    public interface IMoveLogic 
    {
        void DoUpdate(UnitMoveable unit,float deltaTime);
        void SetDestination(Vector3 destination);
    }
}
