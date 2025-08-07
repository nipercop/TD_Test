using Game.GamePlayCore.Stats;
using UnityEngine;

namespace Game.GamePlayCore.Systems.GamePlayState
{
    [System.Serializable]
    public class WaveData
    {
        public GameObject PrefabEnemy;
        public int Count;
        public StatsUnit Stats;
    }
}
