using Game.GamePlayCore.Interfaces.Units.Logic.Move;
using UnityEngine;

namespace Game.GamePlayCore.Units.Logic.Move
{
    public class SimpleMove: IMoveLogic
    {
        Vector3 _destination;
        public void DoUpdate(float deltaTime)
        {
            
        }

        public void SetDestination(Vector3 destination)
        {
            _destination = destination;
        }
    }
}
