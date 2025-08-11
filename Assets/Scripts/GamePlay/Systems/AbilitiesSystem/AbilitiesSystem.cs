using System.Threading;
using Cysharp.Threading.Tasks;
using Game.DataBase.Abilities;
using Game.DataBase.Interfaces.Abilities;
using Game.DataBase.Loader;
using Game.GamePlayCore.Interfaces.Abilities;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.GamePlayCore.Abilities
{
    public class AbilitiesSystem : IAbilitiesSystem , IAsyncStartable
    {
        [Inject] private readonly ScriptableObjectLoader _loader;
        private AbilityData[] _datas;
        public AbilityData[] Datas => _datas;

        public async Awaitable StartAsync(CancellationToken cancellation = new CancellationToken())
        {
            await _loader.LoadAsync<IAbilityDataBase>("AbilitiesDataBase",
                abilitiesDB =>
                {
                    Debug.Log("Abilities count = " + abilitiesDB.AbilityDatas.Length);
                    _datas = abilitiesDB.AbilityDatas;
                }, exception =>
                {
                    Debug.LogError(exception.Message);
                });
        }
    }
}
