using UnityEngine;

namespace Game.DataBase.Abilities
{ 
    [CreateAssetMenu(fileName = "Ability Tickable Data", menuName = "Game/DataBase/Ability/Ability Tickable Data")]
    public class AbilityTickableData : AbilityWithLifeTimeData
    {
        [SerializeField] private float _tickTime;
        [SerializeField] private int _maxStacks;
        public override float TickTime => _tickTime;
        public override int MaxStacks => _maxStacks;
    }
}
