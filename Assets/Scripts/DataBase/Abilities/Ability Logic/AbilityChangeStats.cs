using Game.Abstractions.Ability;
using UnityEngine;

namespace Game.DataBase.Abilities.Logic
{
    [CreateAssetMenu(fileName = "Ability Change Stats", menuName = "Game/DataBase/Ability/Logics/Ability Change Stats")]
    public class AbilityChangeStats : AbilityLogicCore
    {
        public SimpleStatChange statsChanger;
        public override void Activate(IAbilityTarget target)
        {
            var stats = target.Stats;
            stats.IncreaseValue(Id, statsChanger);
            target.Stats = stats;
        }

        public override void Deactivate(IAbilityTarget target)
        {
            var stats = target.Stats;
            stats.DecreaseValue(Id, statsChanger);
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
