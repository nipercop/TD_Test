using ECS.Systems.Abilities.Enums;
using UnityEngine;

namespace Game.DataBase.Abilities
{
    [CreateAssetMenu(fileName = "Ability Data", menuName = "Game/DataBase/Ability/Ability Data")]
    public class AbilityData : ScriptableObject //, IAbilityData
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name;
        [SerializeField] private float _coolDown;
        [SerializeField] private float _duration;
        [SerializeField] private AbilityType  _type;
        [SerializeField] private float _value;
        
        public int Id => _id;
        public string Name => _name;
        public virtual float Duration => _duration;
        public virtual float TickTime => 0;
        public virtual int MaxStacks => 1;
        public float CoolDown => _coolDown;
        public AbilityType AbilityType => _type;
        public float Value => _value;
        
        
    }
}
