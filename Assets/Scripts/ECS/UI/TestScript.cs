using Game.ECS.Systems.Abilities.Requests;
using Unity.Entities;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public void OnClick()
    {
        var world = World.DefaultGameObjectInjectionWorld;
        var em = world.EntityManager;

        var request = em.CreateEntity();
        em.AddComponentData(request, new AttackSpeedAbilityRequest()
        {
            Duration = 10,
            Multiplier = 3
        });
    }
}
