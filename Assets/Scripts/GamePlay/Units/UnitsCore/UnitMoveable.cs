using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Units;
using Game.GamePlayCore.Interfaces.Units.Logic.Move;
using Game.GamePlayCore.Systems.Spawners.Data;
using Game.GamePlayCore.Units.Logic.Move;
using UnityEngine;

namespace Game.GamePlayCore.Units
{
    public class UnitMoveable : DamagableUnit //, IMoveable 
    {
        private IMoveLogic _moveLogic;

        protected override void Start()
        {
            base.Start();
            _moveLogic = new SimpleMove();
        }

        // public void UpdateMove(float deltaTime)
        // {
        //     
        // }

        public override void SetSpawnData(SpawnData spawnData)
        {
            base.SetSpawnData(spawnData);
            _moveLogic.SetDestination(spawnData.Destanation);
        }

        public override void DoUpdate(float deltaTime)
        {
            _moveLogic.DoUpdate(deltaTime);
        }
        
        
    }
}
