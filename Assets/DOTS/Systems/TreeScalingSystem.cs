using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

public class TreeScalingSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float dt = Time.DeltaTime;

        JobHandle ageJob = Entities.WithAny<TreeTag>().ForEach((ref AgeComponent age, ref NonUniformScale scale) =>
        {
            float growValue;
           

            growValue = 1 + (dt / 10f);
            scale.Value *= new float3(growValue, growValue, growValue);

        }

        ).Schedule(inputDeps);

        return ageJob;
    }
}
