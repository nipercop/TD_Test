using UnityEngine;

namespace Game.DataBase.Abilities
{
    [CreateAssetMenu(fileName = "Ability DataBase", menuName = "Game/DataBase/Ability/AbilityDataBase")]
    public class AbilityDataBase : ScriptableObject
    {
        [SerializeField] private AbilityData[] _abilityDatas;
        public AbilityData[] AbilityDatas => _abilityDatas;
    }
}
