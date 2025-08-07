using Game.GamePlayCore.Units;
using UnityEngine;

namespace Game.GamePlayCore.Projectiles
{
    public abstract class ProjectileCore : MonoBehaviour
    {
        [SerializeField] protected float _speed = 10;
        [SerializeField] protected int _damage = 10;
        protected Vector3 _destination;
        protected DamagableUnit _target;

        protected virtual void Start() { }

        protected abstract void Update();
        
        
        public virtual void SetTarget(DamagableUnit  target)
        {
            _target = target;
        }

        public virtual void SetDamage(int damage)
        {
            _damage = damage;
        }
    }
}
