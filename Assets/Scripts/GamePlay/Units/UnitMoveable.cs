using Game.GamePlayCore.Interfaces.Units.Logic.Move;
using Game.GamePlayCore.Systems.Spawners.Data;
using Game.GamePlayCore.Units.Logic.Attack;
using Game.GamePlayCore.Units.Logic.Move;
using UnityEngine;

namespace Game.GamePlayCore.Units
{
    public class UnitMoveable : DamagableUnit
    {
        private IMoveLogic _moveLogic = new SimpleMove();
        [SerializeField] private SimpleAttackMelee _simpleAttackMelee;
        private DamagableUnit _targetToMove;

        public override void SetSpawnData(SpawnData spawnData)
        {
            base.SetSpawnData(spawnData);
            _targetToMove =  spawnData.Destination;
            _moveLogic.SetDestination(spawnData.Destination.transform.position);
        }

        public override void DoUpdate(float deltaTime)
        {
            _moveLogic.DoUpdate(this, deltaTime);
            if (_moveLogic.IsDestinationReached())
            {
                _simpleAttackMelee.DealDamage(_stats.Damage, _targetToMove);
                Die();
            }
        }

    }
}
