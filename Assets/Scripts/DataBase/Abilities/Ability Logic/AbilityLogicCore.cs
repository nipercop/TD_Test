using Game.Abstractions.Ability;
using UnityEngine;

namespace Game.DataBase.Abilities.Logic
{
    public abstract class AbilityLogicCore : ScriptableObject
    {
        public abstract void Activate(int abilityId,IAbilityTarget target, IAbilitiesSystemProvider  abilitiesProvider);
        public virtual void Deactivate(int abilityId, IAbilityTarget target, IAbilitiesSystemProvider abilitiesProvider) { }
        public virtual void DoUpdate(float deltaTime) { }
    }
}
