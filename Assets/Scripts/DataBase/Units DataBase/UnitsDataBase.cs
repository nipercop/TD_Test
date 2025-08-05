using UnityEngine;

namespace Game.DataBase.Units
{
    [CreateAssetMenu(fileName = "UnitsDataBase", menuName = "Game/DataBase/UnitsDataBase")]
    public class UnitsDataBase : ScriptableObject
    {
        [SerializeField] UnitData[] _units;
        public UnitData[] Units => _units;
    }
}
