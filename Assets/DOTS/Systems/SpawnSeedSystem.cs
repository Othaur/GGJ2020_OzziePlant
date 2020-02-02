using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

[AlwaysSynchronizeSystem]
public class SpawnSeedSystem :  JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.WithStructuralChanges().WithAll<ReadyToSeedTag, TreeTag>().WithNone<AgeComponent>().WithoutBurst().ForEach((ref Entity id,ref Translation tran) =>
        {

            EntityManager.RemoveComponent(id, typeof(ReadyToSeedTag));

            Entity temp = EntityManager.Instantiate(Settings.SeedPrefab());
            EntityManager.SetComponentData(temp, new Translation { Value = new float3(UnityEngine.Random.Range(-2, 2), 1, UnityEngine.Random.Range(-2, 2)) +tran.Value });

        }).Run();

        return default;
    }

}

