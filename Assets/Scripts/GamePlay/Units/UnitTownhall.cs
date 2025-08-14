using Game.Abstractions.Ability;
using Game.GamePlayCore.Systems.GamePlayState;
using Game.GamePlayCore.Systems.StateMachine;
using UnityEngine;
using VContainer;

namespace Game.GamePlayCore.Units
{
    public class UnitTownhall : DamagableUnit
    {
        [Inject] private GamePlayStateSystem _gamePlayStateSystem;
        public override UnitType UnitType => UnitType.Townhall;

        public override void Die()
        {
            _gamePlayStateSystem.ChangeState(GameState.EndGame);
            base.Die();
        }

    }
}
