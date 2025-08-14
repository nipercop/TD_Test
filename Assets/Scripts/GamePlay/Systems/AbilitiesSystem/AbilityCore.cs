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
        protected readonly IAbilitiesSystemProvider abilitiesProvider;
        
        public float LifeTime => lifeTime;
        public bool IsActive => _isActive;
        

        public AbilityCore(IAbilityData  data, IAbilitiesSystemProvider  abilitiesProvider)
        {
            Id = data.Id;
            Name = data.Name;
            lifeTime = data.Duration;
            logics = data.Logics;
            this.abilitiesProvider = abilitiesProvider;
        }

        public AbilityCore(AbilityCore original, IAbilitiesSystemProvider  abilitiesProvider)
        {
            Id = original.Id;
            Name = original.Name;
            lifeTime = original.lifeTime;
            _isActive = true;
            logics = original.logics;
            this.abilitiesProvider = abilitiesProvider;
        }
        
        public virtual AbilityCore Clone(IAbilitiesSystemProvider provider)
        {
            return new AbilityCore(this, provider);
        }

        public virtual void Activate(DamagableUnit  target)
        {
            _unit = target;
            _isActive = true;
            foreach (var logic in logics)
            {
                logic.Activate(Id, _unit, abilitiesProvider);
            }
        }

        public virtual void Deactivate()
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
                if (_unit == null)
                {
                    _isActive = false;
                }
            }
        }

        public virtual void Clear()
        {
            Name = null;
            _unit = null;
            logics = null;
        }
    }
}
