using UnityEngine;

namespace Game.DataBase.Abilities
{
    [CreateAssetMenu(fileName = "Ability With Life Time Data", menuName = "Game/DataBase/Ability/Ability With Life Time Data")]
    public class AbilityWithLifeTimeData : AbilityData
    {
        [SerializeField] private float _duration;
        public override float Duration => _duration;
    }
}
