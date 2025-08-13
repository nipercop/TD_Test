using Game.DataBase.Abilities.Logic;
using UnityEngine;

namespace Game.DataBase.Abilities
{
    [CreateAssetMenu(fileName = "Ability Data", menuName = "Game/DataBase/Ability/Ability Data")]
    public class AbilityData : ScriptableObject , IAbilityData
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name;
        [SerializeField] private float _coolDown;
        [SerializeField] AbilityLogicCore[] _logics;

        public int Id => _id;
        public string Name => _name;
        public virtual float Duration => 0;
        public float CoolDown => _coolDown;
        public AbilityLogicCore[] Logics => _logics;
    }
}
