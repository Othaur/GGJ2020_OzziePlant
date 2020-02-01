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
        Entities.WithStructuralChanges().WithoutBurst().ForEach((ref Age age, in Entity id) =>
        {
            if (age.Value > 4)
            {
               EntityManager.RemoveComponent(id, typeof(Age));
                
            }

        }

        ).Run();

        return default;
    }
}
