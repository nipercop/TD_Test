using Game.Abstractions.Ability;
using Game.DataBase.Abilities;
using UnityEngine;

namespace Game.GamePlayCore.Abilities
{
    public class AbilityTickable : AbilityCore
    {
        private float _tickTime;
        private int _maxStacks;
        private float _timerTick = 0;
        private int _currentStack = 1;
        
        public AbilityTickable(IAbilityData data, IAbilitiesSystemProvider  abilitiesProvider) : base(data, abilitiesProvider)
        {
            _tickTime = data.TickTime;
            _maxStacks = data.MaxStacks;
        }

        public AbilityTickable(AbilityTickable original, IAbilitiesSystemProvider  abilitiesProvider) : base(original, abilitiesProvider)
        {
           _tickTime = original._tickTime;
           _maxStacks = original._maxStacks;
        }

        public override void DoUpdate(float deltaTime)
        {
            base.DoUpdate(deltaTime);
            _timerTick+= deltaTime;
            if (_timerTick > _tickTime)
            {
                _timerTick -= _tickTime;
                _currentStack++;
                if (_currentStack > _maxStacks)
                {
                    _currentStack = _maxStacks;
                }
                if (_unit != null)
                {
                    foreach (var logic in logics)
                    {
                        logic.Activate(Id, _currentStack, _unit, abilitiesProvider);
                    }
                }
            }
        }
        
        public override AbilityCore Clone(IAbilitiesSystemProvider provider)
        {
            return new AbilityTickable(this, provider);
        }
    }
}
