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
    public class UnitMoveable : DamagableUnit //, IMoveable 
    {
        private IMoveLogic _moveLogic;
        [SerializeField] private Vector3 _destination;

        protected override void Start()
        {
            base.Start();
            _moveLogic = new SimpleMove(this);
            _moveLogic.SetDestination(_destination);
            _unitsSystem.AddUnit(this);
            _gamePlayUpdater.AddUpdatable(this);
        }

        protected void OnDestroy()
        {
            _unitsSystem.RemoveUnit(this);
            _gamePlayUpdater.RemoveUpdatable(this);
        }

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
