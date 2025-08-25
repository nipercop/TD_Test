using System;
using ECS.Systems.Abilities;
using Game.DataBase.Abilities;
using Game.ECS.Data.Abilities.Requests;
using Game.UI.Abilities.Model;
using Game.UI.Abilities.View;
using Unity.Entities;
using UnityEngine;

namespace Game.UI.Abilities.Presenter
{
    public class AbilityPanelPresenter : IDisposable
    {
        
        private AbilityPanelView _view;
        private readonly AbilityPanelModel _model;
        private readonly AbilityDataBase _abilityDataBase;

        public AbilityPanelPresenter(AbilityPanelModel model, AbilityDataBase  abilityDataBase)
        {
            _abilityDataBase = abilityDataBase;   
            _model = model;
        }

        public void SetView(AbilityPanelView view)
        {
            _view = view;
        }

        public void CreateAbilityButtons()
        {
            foreach (var abilityData in _abilityDataBase.AbilityDatas)
            {
                _view.CreateAbilityButton(abilityData);
            }
        }

        public void OnAbilityClicked(int abilityId)
        {
            Debug.Log("Ability Clicked id " + abilityId);
            foreach (var abilityData in _abilityDataBase.AbilityDatas)
            {
                if (abilityData.Id == abilityId)
                {
                    ExecuteAbility(abilityData);
                }
            }
            _view.RemoveAbility(abilityId);
        }

        private void ExecuteAbility(AbilityData ability)
        {
            var world = World.DefaultGameObjectInjectionWorld;
            var em = world.EntityManager;

            var request = em.CreateEntity();
            em.AddComponentData(request, new AbilityRequest());
            var buffer = em.AddBuffer<AbilityElementData>(request);
            buffer.Add(new AbilityElementData()
            {
                Type = ability.AbilityType,
                Value = ability.Value,
                Duration = ability.Duration,
            });
        }

        public void Dispose()
        {
            _view = null;
        }
    }
}
