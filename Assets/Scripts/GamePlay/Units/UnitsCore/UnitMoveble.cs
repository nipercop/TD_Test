using Game.GamePlayCore.Interfaces.Units;
using UnityEngine;

namespace Game.GamePlayCore.Units
{
    public class UnitMoveble : DamagableUnit , IMoveable
    {
        protected override void Start()
        {
            base.Start();
            
        }

        public void UpdateMove(float deltaTime)
        {
            
        }
    }
}
