using Game.DataBase.Units;
using UnityEngine;

namespace Game.DataBase.Abilities.Logic
{
    [System.Serializable]
    public class AbilityChangeStats : AbilityLogicCore
    {
        public StatsType statType;
        public StatsChangeType statsChangeType;
        public float Value;
    }
}
