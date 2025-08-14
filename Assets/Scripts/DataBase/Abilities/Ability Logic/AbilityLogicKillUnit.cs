using Game.Abstractions.Ability;
using UnityEngine;

namespace Game.DataBase.Abilities.Logic
{
    [CreateAssetMenu(fileName = "Logic Ability Kill Unit", menuName = "Game/DataBase/Ability/Logics/Logic Ability Kill Unit")]
    public class AbilityLogicKillUnit : AbilityLogicCore
    {
        [SerializeField] private UnitType _targets;
        public override void Activate(int abilityId, IAbilityTarget target, IAbilitiesSystemProvider  abilitiesProvider)
        {
            if (_targets.HasFlag(target.UnitType))
            {
                float resultDamage = target.Stats.Health / (1f - target.Stats.ReceiveDamageResistance);
                target.TakeDamage(Mathf.CeilToInt(resultDamage));
                //target.Die(); // this can avoid immortality ability
            }
        }
    }
}
