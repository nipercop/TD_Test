using System;
using Game.GamePlayCore.Interfaces.Units.Logic;
using Game.GamePlayCore.Interfaces.Units.Logic.Move;
using UnityEngine;

namespace Game.GamePlayCore.Units.Logic.Move
{
    public class SimpleMove : IMoveLogic
    {
        private Vector3 _destination;
        private bool _destinationReached;
        
        public void DoUpdate(UnitMoveable unit, float deltaTime)
        {
            if (_destinationReached)
            {
                return;
            }
            var trans = unit.transform;
            Vector3 position = trans.position;
            Vector3 direction = _destination - position;
            float distanceSqr = direction.sqrMagnitude;
            if (distanceSqr > 0.1f)
            {
                trans.LookAt(_destination);
                trans.Translate(trans.forward * (deltaTime * unit.Stats.MoveSpeed), Space.World);
            }
            else
            {
                _destinationReached = true;
            }
        }

        public void SetDestination(Vector3 destination)
        {
            _destinationReached = false;
            _destination = destination;
        }

        public bool IsDestinationReached()
        {
            return _destinationReached;
        }

    }
}
