using Game.GamePlayCore.Interfaces.Units.Logic.Move;
using UnityEngine;

namespace Game.GamePlayCore.Units.Logic.Move
{
    public class SimpleMove: IMoveLogic
    {
        private Vector3 _destination;
        private readonly DamagableUnit _unit;

        public SimpleMove(DamagableUnit unit)
        {
            _unit = unit;
        }
        
        public void DoUpdate(float deltaTime)
        {
            var trans = _unit.transform;
            Vector3 position = trans.position;
            Vector3 direction = _destination - position;
            float distanceSqr = direction.sqrMagnitude;
            if (distanceSqr > 0.1f)
            {
                trans.LookAt(_destination);
                trans.Translate(trans.forward * (deltaTime * _unit.Stats.MoveSpeed), Space.World);
            }
        }

        public void SetDestination(Vector3 destination)
        {
            _destination = destination;
        }
    }
}
