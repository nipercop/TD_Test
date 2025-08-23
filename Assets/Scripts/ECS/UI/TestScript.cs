using ECS.Systems.Abilities;
using ECS.Systems.Abilities.Enums;
using Game.ECS.Data;
using Game.ECS.Data.Abilities.Requests;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public void OnClickIncreaseSpeed()
    {
        var world = World.DefaultGameObjectInjectionWorld;
        var em = world.EntityManager;

        var request = em.CreateEntity();
        em.AddComponentData(request, new AbilityRequest());
        var buffer = em.AddBuffer<AbilityElementData>(request);
        buffer.Add(new AbilityElementData()
        {
            Type = AbilityType.AttackSpeed ,
            Value = 3,
            Duration = 10
        });
        
        //надо реализовать базу данных
    }
    
    public void OnClickKamikadze()
    {
        var world = World.DefaultGameObjectInjectionWorld;
        var em = world.EntityManager;

        var request = em.CreateEntity();
        em.AddComponentData(request, new AbilityRequest());
        var buffer = em.AddBuffer<AbilityElementData>(request);
        buffer.Add(new AbilityElementData()
        {
            Type = AbilityType.Damage ,
            Value = 15,
            Duration = 30
        });
        
    }
    
    public void OnClickSlowDownEnemies()
    {
        var world = World.DefaultGameObjectInjectionWorld;
        var em = world.EntityManager;

        var request = em.CreateEntity();
        em.AddComponentData(request, new AbilityRequest());
        var buffer = em.AddBuffer<AbilityElementData>(request);
        buffer.Add(new AbilityElementData()
        {
            Type = AbilityType.MoveSpeed ,
            Value = .5f,
            Duration = 10 
        });
        
    }
}
