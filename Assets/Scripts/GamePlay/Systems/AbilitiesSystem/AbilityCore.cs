using Game.DataBase.Abilities;
using UnityEngine;

namespace Game.GamePlayCore.Abilities
{
    public class AbilityCore
    {
        public int Id { get; }
        public string Name { get; }

        public AbilityCore(AbilityData  data)
        {
            Id = data.Id;
            Name = data.Name;
        }
    }
}
