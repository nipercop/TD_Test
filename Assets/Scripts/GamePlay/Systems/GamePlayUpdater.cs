using UnityEngine;

namespace Game.GamePlayCore.Systems.Updater
{
    public class GamePlayUpdater : MonoBehaviour
    {
        
        private MoveSystem _moveSystem = new MoveSystem();
        private AttackSystem _attackSystem = new AttackSystem();
        
        void Update()
        {
            float deltaTime = Time.deltaTime;
            _moveSystem.DoUpdate(deltaTime);
            _attackSystem.DoUpdate(deltaTime);
        }
    }
}
