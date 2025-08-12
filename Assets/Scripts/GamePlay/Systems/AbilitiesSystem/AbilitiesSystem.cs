using System.Threading;
using Game.DataBase.Interfaces.Abilities;
using Game.DataBase.Loader;
using Game.GamePlayCore.Interfaces.Abilities;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using System;

namespace Game.GamePlayCore.Abilities
{
    public class AbilitiesSystem : IAbilitiesSystem , IAsyncStartable
    {
        [Inject] private readonly ScriptableObjectLoader _loader;
        private AbilityCore[] _datas;
        public AbilityCore[] Datas => _datas;
        
        public event Action AbilitiesLoaded;

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
                _datas[i] = new AbilityCore(dataBase.AbilityDatas[i]);
            }
        }
    }
}
