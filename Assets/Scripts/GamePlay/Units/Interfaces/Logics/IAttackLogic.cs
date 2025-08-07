using UnityEngine;

namespace Game.GamePlayCore.Interfaces.Units.Logic.Attack
{
    public interface IAttackLogic
    {
        void DoUpdate(IAttackable attackableUnit, float deltaTime);
    }
}
