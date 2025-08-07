using System;
using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Units;
using Game.GamePlayCore.Interfaces.Units.Logic.Attack;
using Game.GamePlayCore.Stats;
using Game.GamePlayCore.Systems.Spawners.Data;
using Game.GamePlayCore.Systems.Units;
using Game.GamePlayCore.Units.Logic.Attack;
using UnityEngine;

namespace Game.GamePlayCore.Units
{
    public class UnitStationary : DamagableUnit , IAttackable
    {
        [SerializeField] private SimpleAttack _attackLogic;
        
        public UnitsSystem  UnitsSystem => _unitsSystem;
        public Transform UnitTransform => transform;

        protected override void Start()
        {
            base.Start();
            
        }

        public override void SetSpawnData(SpawnData spawnData)
        {
            base.SetSpawnData(spawnData);
            _attackLogic.SetStats(_stats);
        }

        public override void DoUpdate(float deltaTime)
        {
            base.DoUpdate(deltaTime);
            _attackLogic.DoUpdate(this, deltaTime);
        }

    }
}
