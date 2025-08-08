using Game.DataBase.Abilities;
using UnityEngine;

namespace Game.DataBase.Interfaces.Abilities
{
    public interface IAbilityDataBase: IDataBase
    {
        AbilityData[] AbilityDatas { get; }
    }
}
