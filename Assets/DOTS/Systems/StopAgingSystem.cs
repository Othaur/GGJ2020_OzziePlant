using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;

[AlwaysSynchronizeSystem]
public class StopAgingSystem : JobComponentSystem
{

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.WithStructuralChanges().WithoutBurst().ForEach((ref AgeComponent age, in Entity id) =>
        {
            if (age.Value > 4)
            {
               EntityManager.RemoveComponent(id, typeof(AgeComponent));
                EntityManager.AddComponent(id, typeof(ReadyToSeedTag));
                
            }

        }

        ).Run();

        return default;
    }
}
