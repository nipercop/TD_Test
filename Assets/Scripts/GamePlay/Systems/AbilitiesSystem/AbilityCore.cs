using Game.DataBase.Abilities;
using Game.DataBase.Abilities.Logic;
using Game.GamePlayCore.Units;
using UnityEngine;

namespace Game.GamePlayCore.Abilities
{
    public class AbilityCore
    {
        public int Id { get; }
        public string Name { get; private set; }
        protected DamagableUnit _unit;
        protected float lifeTime;
        protected bool _isActive;
        protected AbilityLogicCore[] logics;
        
        public float LifeTime => lifeTime;
        public bool IsActive => _isActive;
        

        public AbilityCore(AbilityData  data)
        {
            Id = data.Id;
            Name = data.Name;
            lifeTime = data.LifeTime;
            logics = data.Logics;
        }

        public AbilityCore(AbilityCore original, DamagableUnit target)
        {
            Id = original.Id;
            Name = original.Name;
            lifeTime = original.lifeTime;
            _unit = target;
            _isActive = true;
            logics = original.logics;
        }

        public virtual void Activate(DamagableUnit  target)
        {
            _unit = target;
            _isActive = true;
            foreach (var logic in logics)
            {
                logic.Activate(_unit);
            }
            //_unit.IncreaseStats(Id, statsToChange);
        }

        public virtual void Deactivate()
        {
            if (_unit != null)
            {
                foreach (var logic in logics)
                {
                    logic.Deactivate(_unit);
                }
            }
            _unit = null;
            _isActive = false;
        }
        

        public virtual void DoUpdate(float deltaTime)
        {
            lifeTime -= deltaTime;
            if (_isActive && lifeTime > 0)
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
