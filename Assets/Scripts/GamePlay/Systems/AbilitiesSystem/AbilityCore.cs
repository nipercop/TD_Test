using Game.Abstractions.Ability;
using Game.DataBase.Abilities;
using Game.DataBase.Abilities.Logic;
using Game.GamePlayCore.Units;

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
        

        public AbilityCore(IAbilityData  data)
        {
            Id = data.Id;
            Name = data.Name;
            lifeTime = data.Duration;
            logics = data.Logics;
        }

        public AbilityCore(AbilityCore original)
        {
            Id = original.Id;
            Name = original.Name;
            lifeTime = original.lifeTime;
            _isActive = true;
            logics = original.logics;
        }

        public virtual void Activate(DamagableUnit  target, IAbilitiesSystemProvider  abilitiesProvider)
        {
            _unit = target;
            _isActive = true;
            foreach (var logic in logics)
            {
                logic.Activate(Id, _unit, abilitiesProvider);
            }
        }

        public virtual void Deactivate(IAbilitiesSystemProvider  abilitiesProvider)
        {
            if (_unit != null)
            {
                foreach (var logic in logics)
                {
                    logic.Deactivate(Id, _unit, abilitiesProvider);
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
