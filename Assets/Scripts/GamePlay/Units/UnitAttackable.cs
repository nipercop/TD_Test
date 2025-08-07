using Game.GamePlayCore.Interfaces.Units;
using Game.GamePlayCore.Systems.Units;
using Game.GamePlayCore.Units.Logic.Attack;
using UnityEngine;

namespace Game.GamePlayCore.Units
{
    public class UnitAttackable : DamagableUnit , IAttackable
    {
        [SerializeField] private SimpleAttack _attackLogic;
        
        public UnitsSystem  UnitsSystem => _unitsSystem;
        public Transform UnitTransform => transform;
        

        public override void DoUpdate(float deltaTime)
        {
            base.DoUpdate(deltaTime);
            _attackLogic.DoUpdate(this, deltaTime);
        }

    }
}
