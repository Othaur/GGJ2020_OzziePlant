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
        float growSpeed = Settings.growRate;

        JobHandle ageJob = Entities.ForEach((ref AgeComponent age) =>
        {
            float growValue;
            age.Value += (dt / growSpeed);        
            
        }).Schedule(inputDeps);

        return ageJob;
    }
}
