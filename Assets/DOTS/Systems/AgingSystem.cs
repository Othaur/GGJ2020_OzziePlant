using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

public class AgingSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float dt = Time.DeltaTime;

        JobHandle ageJob = Entities.ForEach((ref Age age, ref NonUniformScale scale) =>
        {
            float growValue;
            age.Value += (dt / 10f);

            growValue = 1 + (dt / 10f);
            scale.Value *= new float3(growValue, growValue, growValue);
            
        }

        ).Schedule(inputDeps);

        return ageJob;
    }
}
