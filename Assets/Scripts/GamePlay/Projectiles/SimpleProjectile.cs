using Game.GamePlayCore.Units;
using UnityEngine;

namespace Game.GamePlayCore.Projectiles
{
    public class SimpleProjectile : ProjectileCore
    {
        protected override void Update()
        {
            if (_target)
            {
                _destination = _target.transform.position;
            }
            
            Vector3 direction = _destination - transform.position;
            float sqrDistance = direction.sqrMagnitude;
            transform.position = Vector3.MoveTowards(transform.position, _destination, Time.deltaTime * _speed);
            
            if (sqrDistance < .5f)
            {
                if (_target)
                {
                    _target.TakeDamage(_damage);
                }
                Destroy(gameObject);
            }
        }

    }
}
