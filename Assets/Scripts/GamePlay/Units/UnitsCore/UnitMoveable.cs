using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Units;
using UnityEngine;

namespace Game.GamePlayCore.Units
{
    public class UnitMoveable : DamagableUnit , IMoveable 
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
