using Game.DataBase.Units;
using UnityEngine;

namespace Game.DataBase.Interfaces.Units
{
    public interface IUnitsDataBase: IDataBase
    {
        UnitData[] Units { get; }
    }
}