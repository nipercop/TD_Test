using UnityEngine;

namespace Game.DataBase.Abilities
{
    [CreateAssetMenu(fileName = "Ability Data", menuName = "Game/DataBase/Ability/Ability Data")]
    public class AbilityData : ScriptableObject
    {
        public int Id;
        public string Name;
        
    }
}
