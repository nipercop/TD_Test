using Game.Abstractions.Ability;
using UnityEngine;

namespace Game.DataBase.Abilities.Logic
{
    [CreateAssetMenu(fileName = "Logic Ability Change Stats", menuName = "Game/DataBase/Ability/Logics/Logic Ability Change Stats")]
    public class AbilityChangeStats : AbilityLogicCore
    {
        public SimpleStatChange statsChanger;
        public override void Activate(int abilityId, IAbilityTarget target, IAbilitiesSystemProvider  abilitiesProvider)
        {
            var stats = target.Stats;
            stats.IncreaseValue(abilityId, statsChanger);
            target.Stats = stats;
        }

        public override void Deactivate(int abilityId, IAbilityTarget target, IAbilitiesSystemProvider  abilitiesProvider)
        {
            var stats = target.Stats;
            stats.DecreaseValue(abilityId, statsChanger);
            target.Stats = stats;
        }
    }
    
    [System.Serializable]
    public class SimpleStatChange : IAbilityChangeStats
    {
        [SerializeField] private StatsType _statsType;
        [SerializeField] private StatsChangeType _statsChangeType;
        [SerializeField] private float _value;
        public StatsType StatType => _statsType;
        public StatsChangeType StatsChangeType => _statsChangeType;
        public float Value =>  _value;

        public SimpleStatChange(StatsType statsType, StatsChangeType changeType, float value)
        {
            _statsType = statsType;
            _statsChangeType = changeType;
            _value = value;
        }
    }
}
