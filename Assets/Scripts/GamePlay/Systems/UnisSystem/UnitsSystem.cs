using System.Collections.Generic;
using Game.GamePlayCore.Units;
using UnityEngine;

namespace Game.GamePlayCore.Systems.Units
{
    public class UnitsSystem : MonoBehaviour
    {
        [SerializeField] private List<DamagableUnit> _units = new List<DamagableUnit>();
        public List<DamagableUnit> Units => _units;
        
        public void AddUnit(DamagableUnit unit)
        {
            _units.Add(unit);
        }

        public void RemoveUnit(DamagableUnit unit)
        {
            _units.Remove(unit);
        }
    }
}
