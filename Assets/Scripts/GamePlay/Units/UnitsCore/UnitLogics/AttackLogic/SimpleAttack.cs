using Game.GamePlayCore.Interfaces.Units;
using Game.GamePlayCore.Interfaces.Units.Logic.Attack;
using Game.GamePlayCore.Stats;
using Game.GamePlayCore.Systems.Spawners.Data;
using UnityEngine;

namespace Game.GamePlayCore.Units.Logic.Attack
{
    public class SimpleAttack: MonoBehaviour //,  IAttackLogic
    {
        private float _timerAttack = 0;
        private DamagableUnit _target;
        
        [SerializeField] private float _radiusAttack = 10;
        
        public void SetStats(StatsUnit statsUnit)
        {
            
        }
        
        public void DoUpdate(IAttackable attackableUnit, float deltaTime)
        {
            if (!_target)
            {
                _timerAttack -= deltaTime;
                TryAttackTarget();
            }
            else
            {
                FindTarget(attackableUnit);
            }
        }

        private void FindTarget(IAttackable attackableUnit)
        {
            var targets = attackableUnit.UnitsSystem.Units;
            
        }

        private void TryAttackTarget()
        {
            if (_timerAttack <= 0)
            {
                _timerAttack = .5f;
            }
        }
    }
}
