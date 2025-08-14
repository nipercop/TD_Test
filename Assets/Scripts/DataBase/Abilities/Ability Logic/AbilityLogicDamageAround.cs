using Game.Abstractions.Ability;
using UnityEngine;

namespace Game.DataBase.Abilities.Logic
{
    [CreateAssetMenu(fileName = "Logic Ability Damage Around", menuName = "Game/DataBase/Ability/Logics/Logic Ability Damage Around")]
    public class AbilityLogicDamageAround : AbilityLogicCore
    {
        [SerializeField] int _damage;
        [SerializeField] float _radius;
        
        public override void Activate(int abilityId, IAbilityTarget target, IAbilitiesSystemProvider  abilitiesProvider)
        {
            var faction = target.Faction;
            var units = abilitiesProvider.AllUnits;
            foreach (var unit in units)
            {
                if (unit.Faction != faction && Vector3.Distance(target.Position, unit.Position) <= _radius)
                {
                    unit.TakeDamage(_damage);
                }
            }
            
        }
    }
}
