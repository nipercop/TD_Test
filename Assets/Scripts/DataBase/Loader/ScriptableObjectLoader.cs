using System;
using System.Threading.Tasks;
using CardRogue.DataBase.Interfaces.Loader;
using Cysharp.Threading.Tasks;
using Game.DataBase.Interfaces;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.DataBase.Loader
{
    public class ScriptableObjectLoader : IDataLoader
    {
        public async UniTask LoadAsync<T>(string address, Action<T> onComplete, Action<Exception> onError = null)
        {
            try
            {
                var result = await Addressables.LoadAssetAsync<T>(address).ToUniTask();
                onComplete.Invoke(result);
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex);
                throw;
            }
        }
    }
}
