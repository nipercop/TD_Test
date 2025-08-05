using System.Collections.Generic;
using Game.GamePlayCore.Interfaces.Units;
using UnityEngine;

namespace  Game.GamePlayCore.Systems.Updater
{
    public class AttackSystem
    {
        
        private List<IAttackable> _attackables = new List<IAttackable>();

        public void AddMoveable(IAttackable atackable)
        {
            _attackables.Add(atackable);
        }

        public void RemoveMoveable(IAttackable atackable)
        {
            _attackables.Remove(atackable);
        }
        
        public void DoUpdate(float deltaTime)
        {
            int count = _attackables.Count;
            for (int i = 0; i < count; i++)
            {
                _attackables[i].UpdateAttack(deltaTime);
            }
        }
    }
}
