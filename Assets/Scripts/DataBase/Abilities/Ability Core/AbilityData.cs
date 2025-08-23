using UnityEngine;

namespace Game.DataBase.Abilities
{
    [CreateAssetMenu(fileName = "Ability Data", menuName = "Game/DataBase/Ability/Ability Data")]
    public class AbilityData : ScriptableObject //, IAbilityData
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name;
        [SerializeField] private float _coolDown;
        
        public int Id => _id;
        public string Name => _name;
        public virtual float Duration => 0;
        public virtual float TickTime => 0;
        public virtual int MaxStacks => 1;
        public float CoolDown => _coolDown;
        
        
    }
}
