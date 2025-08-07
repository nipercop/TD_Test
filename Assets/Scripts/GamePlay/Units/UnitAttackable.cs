using Game.GamePlayCore.Interfaces.Units;
using Game.GamePlayCore.Systems.Units;
using Game.GamePlayCore.Units.Logic.Attack;
using UnityEngine;

namespace Game.GamePlayCore.Units
{
    public class UnitAttackable : DamagableUnit , IAttackable
    {
        [SerializeField] private SimpleAttackProjectile attackProjectileLogic;
        
        public UnitsSystem  UnitsSystem => _unitsSystem;
        public Transform UnitTransform => transform;
        

        public override void DoUpdate(float deltaTime)
        {
            base.DoUpdate(deltaTime);
            attackProjectileLogic.DoUpdate(this, deltaTime);
        }

    }
}
