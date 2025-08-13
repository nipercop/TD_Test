using Game.DataBase.Abilities;
using Game.GamePlayCore.Units;
using UnityEngine;

namespace Game.GamePlayCore.Abilities
{
    public class AbilityCore
    {
        public int Id { get; }
        public string Name { get; private set; }
        protected DamagableUnit _unit;
        protected float _lifeTime;
        protected bool _isActive;
        
        public float LifeTime => _lifeTime;
        public bool IsActive => _isActive;
        

        public AbilityCore(AbilityData  data)
        {
            Id = data.Id;
            Name = data.Name;
            _lifeTime = data.LifeTime;
        }

        public AbilityCore(AbilityCore original, DamagableUnit target)
        {
            Id = original.Id;
            Name = original.Name;
            _lifeTime = original._lifeTime;
            _unit = target;
            _isActive = true;
        }

        public virtual void Activate(DamagableUnit  target)
        {
            _unit = target;
            _isActive = true;
            Debug.Log("Activate id =" + Id, target);
        }

        public virtual void Deactivate()
        {
            _unit = null;
            _isActive = false;
            Debug.Log("Deactivate id = " + Id);
        }

        public virtual void DoUpdate(float deltaTime)
        {
            _lifeTime -= deltaTime;
            if (_isActive && _lifeTime > 0)
            {
                if (_unit != null)
                {
                    
                }
                else
                {
                    _isActive = false;
                }
            }
        }

        public virtual void Clear()
        {
            Name = null;
            _unit = null;
        }
    }
}
