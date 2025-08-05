using Game.GamePlayCore.Interfaces.Units;
using UnityEngine;

namespace Game.GamePlayCore.Units
{
    public class UnitStationary : DamagableUnit, IAttackable
    {
        
        protected override void Start()
        {
            base.Start();
            
        }
        
        public void UpdateAttack(float  deltaTime)
        {
            
        }
    }
}
