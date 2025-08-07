using Game.GamePlayCore.Interfaces.Units;
using Game.GamePlayCore.Interfaces.Units.Logic.Attack;
using Game.GamePlayCore.Projectiles;
using Game.GamePlayCore.Stats;
using Game.GamePlayCore.Systems.Spawners.Data;
using UnityEngine;

namespace Game.GamePlayCore.Units.Logic.Attack
{
    public class SimpleAttack: MonoBehaviour //,  IAttackLogic
    {
        [SerializeField] private float _timerAttack = 0;
        [SerializeField] private DamagableUnit _target;
        [SerializeField] private float _radiusAttack = 5;
        [SerializeField] GameObject _projectile;
        
        public void DoUpdate(IAttackable attackableUnit, float deltaTime)
        {
            if (_target != null)
            {
                _timerAttack -= deltaTime * attackableUnit.Stats.AttackSpeed;
                TryAttackTarget( attackableUnit);
            }
            else
            {
                FindTarget(attackableUnit);
            }
        }

        private void FindTarget(IAttackable attackableUnit)
        {
            Vector3 attackerPosition = attackableUnit.UnitTransform.position;
            var targets = attackableUnit.UnitsSystem.Units;
            float distance = float.MaxValue;
            DamagableUnit target = null;
            for (var i = 0; i < targets.Count; i++)
            {
                var unit = targets[i];
                float sqrDist = GetSqrDistance(attackerPosition, unit);
                if (sqrDist < distance && sqrDist < _radiusAttack * _radiusAttack)
                {
                    distance = sqrDist;
                    target = unit;
                }
            }
            _target = target;
        }

        private void TryAttackTarget(IAttackable attackableUnit)
        {
            float sqrDist = GetSqrDistance(attackableUnit.UnitTransform.position, _target);
            if (sqrDist > _radiusAttack * _radiusAttack)
            {
                _target = null;
                return;
            }

            if (_timerAttack <= 0)
            {
                _timerAttack = 1f;
                var projectile = CreateProjectile(_projectile, transform.position);
                projectile.SetDamage(attackableUnit.Stats.Damage);
                projectile.SetTarget(_target);
            }
        }

        private float GetSqrDistance(Vector3 position1 , DamagableUnit target)
        {
            return  (target.transform.position - position1).sqrMagnitude;
        }

        // TODO nipercop: в будущем можно сделать через ProjectileSpawner, но идею в принципе поняли
        private SimpleProjectile CreateProjectile(GameObject prefab, Vector3 position)
        {
            var go = Instantiate(prefab, position, Quaternion.identity);
            return go.GetComponent<SimpleProjectile>();
        }
    }
}
