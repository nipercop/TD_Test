using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Units;
using Game.GamePlayCore.Interfaces.Units.Logic.Attack;
using Game.GamePlayCore.Units.Logic.Attack;
using UnityEngine;

namespace Game.GamePlayCore.Units
{
    public class UnitStationary : DamagableUnit //, IAttackable
    {
        private IAttackLogic _attackLogic;
        
        protected override void Start()
        {
            base.Start();
            _attackLogic = new SimpleAttack();
        }
        
        // public void UpdateAttack(float  deltaTime)
        // {
        //     
        // }

        public override void DoUpdate(float deltaTime)
        {
            base.DoUpdate(deltaTime);
            _attackLogic.DoUpdate(deltaTime);
        }
    }
}
