using Game.Abstractions.Ability;
using UnityEngine;

namespace Game.DataBase.Abilities.Logic
{
    public abstract class AbilityLogicCore : ScriptableObject
    {
        public int Id;
        public abstract void Activate(IAbilityTarget target);
        public abstract void Deactivate(IAbilityTarget target);
    }
}
