
using UnityEngine;

namespace Game.DataBase.Units
{
    [CreateAssetMenu(fileName = "UnitsDataBase", menuName = "Game/DataBase/Units/UnitsDataBase")]
    public class UnitsDataBase : ScriptableObject
    {
        [SerializeField] UnitData[] _units;
        public UnitData[] Units => _units;
       
    }
}
