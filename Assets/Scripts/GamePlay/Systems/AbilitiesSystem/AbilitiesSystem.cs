using System.Threading;
using Game.DataBase.Interfaces.Abilities;
using Game.DataBase.Loader;
using Game.GamePlayCore.Interfaces.Abilities;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using System;
using System.Collections.Generic;
using Game.Abstractions.Ability;
using Game.DataBase.Abilities;
using Game.GamePlayCore.Systems.Units;
using Game.GamePlayCore.Units;

namespace Game.GamePlayCore.Abilities
{
    public class AbilitiesSystem : IAbilitiesSystem , IAsyncStartable, ITickable, IAbilitiesSystemProvider
    {
        [Inject] private readonly ScriptableObjectLoader _loader;
        [Inject] private readonly UnitsSystem _unitsSystem;
        
        private AbilityCore[] _datas;
        public AbilityCore[] Datas => _datas;
        public IReadOnlyList<IAbilityTarget> AllUnits => _unitsSystem.AllUnits;
        public event Action AbilitiesLoaded;
        private List<AbilityCore> _abilities = new List<AbilityCore>();
        private List<AbilityCore> _toRemove = new List<AbilityCore>();

        public async Awaitable StartAsync(CancellationToken cancellation = new CancellationToken())
        {
            await _loader.LoadAsync<IAbilityDataBase>("AbilitiesDataBase",
                ConvertAbilityDataToGamePlayData, 
                exception =>
                {
                    Debug.LogError(exception.Message);
                });
            AbilitiesLoaded?.Invoke();
        }

        private void ConvertAbilityDataToGamePlayData(IAbilityDataBase dataBase)
        {
            var count = dataBase.AbilityDatas.Length;
            _datas = new AbilityCore[count];
            for (int i=0; i<count; i++)
            {
                _datas[i] = CreateAbilityFromData(dataBase.AbilityDatas[i]);
                //_datas[i] = new AbilityCore(dataBase.AbilityDatas[i] , this);
            }
        }
        
        private AbilityCore CreateAbilityFromData(IAbilityData data)
        {
            switch (data.abilityType)
            {
                case AbilityType.Instant:
                case AbilityType.LifeTime:
                    return new AbilityCore(data, this);
                case AbilityType.Tickable:
                    return new AbilityTickable(data, this);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public void ActivateAbility(int id, DamagableUnit target)
        {
            foreach (var abilityCore in _datas)
            {
                if (abilityCore.Id == id)
                {
                    var activatedAbility = abilityCore.Clone(this);
                    activatedAbility.Activate(target);
                    _abilities.Add(activatedAbility);
                }
            }
        }

        public void Tick()
        {
            int count = _abilities.Count;
            float deltaTime = Time.deltaTime;
            for (int i = 0; i < count; i++)
            {
                var currentAbility = _abilities[i];
                currentAbility.DoUpdate(deltaTime);
                if (currentAbility.LifeTime < 0 || !currentAbility.IsActive)
                {
                    currentAbility.Deactivate();
                    _toRemove.Add(currentAbility);
                }
            }

            if (_toRemove.Count > 0)
            {
                foreach (var abilityCore in _toRemove)
                {
                    abilityCore.Clear();
                    _abilities.Remove(abilityCore);
                }
                _toRemove.Clear();
            }
        }
    }
}
