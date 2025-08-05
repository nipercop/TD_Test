using UnityEngine;

namespace Game.DataBase.Units
{
    [CreateAssetMenu(fileName = "Unit Data", menuName = "Game/DataBase/Unit Data")]
    public class UnitData : ScriptableObject
    {
        public int Id;
        public int Health;
        public float MoveSpeed;
        public float AttackSpeed;
    }
}
