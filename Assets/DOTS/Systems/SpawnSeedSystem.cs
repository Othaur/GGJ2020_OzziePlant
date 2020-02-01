using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

public class SpawnSeedSystem :  JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.WithStructuralChanges().WithAll<ReadyToSeedTag>().WithNone<AgeComponent>().WithoutBurst().ForEach((ref Entity id,ref Translation tran) =>
        {

            EntityManager.RemoveComponent(id, typeof(ReadyToSeedTag));
            



        }

        ).Run();

        return default;
    }

}

