using Game.GamePlayCore.Interfaces.Units;
using Game.GamePlayCore.Interfaces.Units.Logic.Attack;
using UnityEngine;

namespace Game.GamePlayCore.Units.Logic.Attack
{
    public class SimpleAttackMelee : MonoBehaviour,  IAttackLogic
    {
        public void DealDamage(int damage, DamagableUnit damageableUnit)
        {
            if (damageableUnit)
            {
                damageableUnit.TakeDamage(damage);
            }
        }
        
        public void DoUpdate(IAttackable attackableUnit, float deltaTime) { }
    }
}
