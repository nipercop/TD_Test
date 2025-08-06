using UnityEngine;

namespace Game.DataBase.Abilities.Logic
{
    public abstract class AbilityLogicCore
    {
        public virtual void Execute(){}
        public virtual void DoUpdate(float deltaTime){}
    }
}
