using Game.DataBase.Interfaces.Units;
using UnityEngine;

namespace Game.DataBase.Units
{
    [CreateAssetMenu(fileName = "UnitsDataBase", menuName = "Game/DataBase/Units/UnitsDataBase")]
    public class UnitsDataBase : ScriptableObject, IUnitsDataBase
    {
        [SerializeField] UnitData[] _units;
        public UnitData[] Units => _units;
        public void Load() { }

        public void Unload() { }
    }
}
