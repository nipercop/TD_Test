using System.Collections.Generic;
using Game.GamePlayCore.Units;
using UnityEngine;

namespace Game.GamePlayCore.Systems.Units
{
    public class UnitsSystem : MonoBehaviour
    {
        private List<DamagableUnit> _enemyUnits = new List<DamagableUnit>();
        private List<DamagableUnit> _playerUnits = new List<DamagableUnit>();
        private List<DamagableUnit> _allUnits = new List<DamagableUnit>();
        public List<DamagableUnit> EnemyUnits => _enemyUnits;
        public List<DamagableUnit> PlayerUnits => _playerUnits;
        public List<DamagableUnit> AllUnits => _allUnits;

        private const int PLAYER_FACTION = 0;
        public void AddUnit(DamagableUnit unit)
        {
            if (unit.Faction == PLAYER_FACTION)
            {
                _playerUnits.Add(unit);
            }
            else
            {
                _enemyUnits.Add(unit);
            }
            _allUnits.Add(unit);
        }

        public void RemoveUnit(DamagableUnit unit)
        {
            if (unit.Faction == PLAYER_FACTION)
            {
                _playerUnits.Remove(unit);
            }
            else
            {
                _enemyUnits.Remove(unit);
            }
            _allUnits.Remove(unit);
        }
    }
}
