using System.Collections.Generic;
using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Systems;
using UnityEngine;

namespace Game.GamePlayCore.Systems.Updater
{
    public class GamePlayUpdater : MonoBehaviour, IGamePlayUpdater
    {
       
        private List<IUpdatable> _updatables = new List<IUpdatable>();

        public void AddUpdatable(IUpdatable updatable)
        {
            Debug.Log("======== AddUpdatable");
            _updatables.Add(updatable);
        }

        public void RemoveUpdatable(IUpdatable updatable)
        {
            Debug.Log("======== RemoveUpdatable");
            _updatables.Remove(updatable);
        }
        
        void Update()
        {
            float deltaTime = Time.deltaTime;
            int count = _updatables.Count;
            for (int i = 0; i < count; i++)
            {
                _updatables[i].DoUpdate(deltaTime);
            }
        }
    }
}
