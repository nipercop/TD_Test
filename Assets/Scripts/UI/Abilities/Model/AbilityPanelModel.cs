using Cysharp.Threading.Tasks;
using Game.DataBase.Interfaces.Abilities;
using Game.DataBase.Loader;
using UnityEngine;
using VContainer;

namespace Game.UI.Abilities.Model
{
    public class AbilityPanelModel
    {
        //[Inject] private readonly ScriptableObjectLoader _loader;
        
        public void LoadDatas()
        {
           //  _loader.LoadAsync<IAbilityDataBase>("AbilitiesDataBase", 
           //     abilitiesDB =>
           //     {
           //         //var abilities = abilitiesDB.GetAllAbilities();
           //     }, exception =>
           // {
           //     Debug.LogError(exception.Message);
           // }).Forget();
        }
    }
}
