using System;
using System.Threading.Tasks;
using CardRogue.DataBase.Interfaces.Loader;
using Game.DataBase.Interfaces;
using UnityEngine.AddressableAssets;

namespace Game.DataBase.Loader
{
    public class ScriptableObjectLoader : IDataLoader
    {
        public async Task<IDataBase> LoadAsync(string address, Action<IDataBase> onComplete, Action<Exception> onError = null)
        {
            try
            {
                var asyncTask = Addressables.LoadAssetAsync<IDataBase>(address);
                await asyncTask.Task;
                
                if (asyncTask.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
                {
                    onComplete?.Invoke(asyncTask.Result);
                    return asyncTask.Result;
                }
                else
                {
                    throw new Exception($"Failed to load ScriptableObject at address: {address}");
                }
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex);
                throw;
            }
        }
    }
}
