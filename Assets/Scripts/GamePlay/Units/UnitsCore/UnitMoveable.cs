using System;
using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Units;
using Game.GamePlayCore.Interfaces.Units.Logic.Move;
using Game.GamePlayCore.Systems.Spawners.Data;
using Game.GamePlayCore.Units.Logic.Move;
using UnityEngine;
using VContainer;

namespace Game.GamePlayCore.Units
{
    public class UnitMoveable : DamagableUnit
    {
        private IMoveLogic _moveLogic = new SimpleMove();

        protected override void Start()
        {
            base.Start();
            _unitsSystem.AddUnit(this);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _unitsSystem.RemoveUnit(this);
        }

        public override void SetSpawnData(SpawnData spawnData)
        {
            base.SetSpawnData(spawnData);
            _moveLogic.SetDestination(spawnData.Destination);
        }

        public override void DoUpdate(float deltaTime)
        {
            _moveLogic.DoUpdate(this, deltaTime);
        }

    }
}
