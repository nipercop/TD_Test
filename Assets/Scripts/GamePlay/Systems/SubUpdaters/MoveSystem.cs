using System.Collections.Generic;
using Game.GamePlayCore.Interfaces.Units;
using UnityEngine;

namespace Game.GamePlayCore.Systems.Updater
{
    public class MoveSystem
    {
        private List<IMoveable> _moveables = new List<IMoveable>();

        public void AddMoveable(IMoveable moveable)
        {
            _moveables.Add(moveable);
        }

        public void RemoveMoveable(IMoveable moveable)
        {
            _moveables.Remove(moveable);
        }
        
        public void DoUpdate(float deltaTime)
        {
            int count = _moveables.Count;
            for (int i = 0; i < count; i++)
            {
                _moveables[i].UpdateMove(deltaTime);
            }
        }
    }
}
