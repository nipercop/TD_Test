using Game.DataBase.Abilities;
using Game.GamePlayCore.Units;
using UnityEngine;

namespace Game.GamePlayCore.Abilities
{
    public class AbilityCore
    {
        public int Id { get; }
        public string Name { get; }

        protected DamagableUnit unit;
        protected float lifeTime;

        public AbilityCore(AbilityData  data)
        {
            Id = data.Id;
            Name = data.Name;
        }

        public AbilityCore(AbilityCore original, DamagableUnit target)
        {
            Id = original.Id;
            Name = original.Name;
            lifeTime = original.lifeTime;
            unit = target;
        }

        public virtual void Activate(DamagableUnit  target)
        {
            unit = target;
        }

        public virtual void Deactivate()
        {
            unit = null;
        }

        public virtual void DoUpdate(float deltaTime)
        {
            
        }
    }
}
