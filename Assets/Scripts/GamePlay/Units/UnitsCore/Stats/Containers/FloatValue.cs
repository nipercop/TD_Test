using System.Collections.Generic;
using Game.Abstractions.Ability;
using Game.DataBase.Abilities.Logic;
using UnityEngine;

namespace Game.GamePlayCore.Stats
{
    public struct ValueChanger
    {
        public StatsChangeType ChangeType;
        public float Value;

        public ValueChanger( StatsChangeType changeType, float value)
        {
            ChangeType = changeType;
            Value = value;
        }
    }
    
    [System.Serializable]
    public struct FloatValue : IFloatValue
    {
        [SerializeField] private float _value;
        private float _valueBase;
        private Dictionary<int,ValueChanger> _changers;
        public float Value => _value;

        public FloatValue(float value)
        {
            _value = value;
            _valueBase = value;
            _changers = new Dictionary<int, ValueChanger>();
        }
        
        public FloatValue(FloatValue floatValue)
        {
            _value = floatValue._value;
            _valueBase = floatValue._value;
            _changers = new Dictionary<int, ValueChanger>();
        }


        public void AddChangeStat(int id, StatsChangeType changeType, float value)
        {
            _changers.TryAdd(id, new ValueChanger(changeType, value));
            Calculate();
        }

        public void RemoveChangeStat(int id)
        {
            _changers.Remove(id);
            Calculate();
        }

        private void Calculate()
        {
            float sumAdd = 0;
            float sumMultiplier = 1;
            foreach (var changer in _changers)
            {
                switch (changer.Value.ChangeType)
                {
                    case StatsChangeType.Additive:
                        sumAdd += changer.Value.Value;
                        break;
                    case StatsChangeType.Percentage:
                        sumMultiplier += changer.Value.Value;
                        break;
                }
            }
            _value = (_valueBase + sumAdd ) * sumMultiplier;
        }
    }
}
