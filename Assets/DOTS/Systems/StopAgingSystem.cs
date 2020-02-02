using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Rendering;
using Unity.Transforms;
using Unity.Mathematics;

[AlwaysSynchronizeSystem]
public class StopAgingSystem : JobComponentSystem
{

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.WithStructuralChanges().WithoutBurst().WithAll<TreeTag>().ForEach((ref AgeComponent age, in Entity id) =>
        {
            if (age.Value > 4)
            {
               EntityManager.RemoveComponent(id, typeof(AgeComponent));
                EntityManager.AddComponent(id, typeof(ReadyToSeedTag));

                 RenderMesh tempMesh = World.Active.EntityManager.GetSharedComponentData<RenderMesh>(id);
                 tempMesh.mesh = Settings.Stage2Prefab();

                EntityManager.SetSharedComponentData(id, new RenderMesh { mesh = tempMesh.mesh, material = tempMesh.material });

            }

        }

        ).Run();

        return default;
    }
}
