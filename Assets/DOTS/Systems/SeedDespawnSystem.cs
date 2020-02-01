using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Burst;
using Unity.Collections;

// This system updates all entities in the scene with both a RotationSpeed_ForEach and Rotation component.

// ReSharper disable once InconsistentNaming
public class SeedDespawnSystem : JobComponentSystem
{
    EntityCommandBufferSystem m_Barrier;

    protected override void OnCreate()
    {
        m_Barrier = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }
    /*
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        float deltaTime = Time.DeltaTime;
        
        var jobHandle = Entities
            .WithName("SeedEntity")
            .ForEach((ref Entity entity, int jobIndex, ref AgeComponent age) =>
            {
                age.age -= deltaTime;
                if(age.age > age.lifespan)
                {
                    PostUpdateCommands.DestroyEntity(entity);
                }
            })
            .Schedule(inputDependencies);
        
        return jobHandle;
    }
    */
    [BurstCompile]
    struct LifeTimeJob : IJobForEachWithEntity<AgeComponent, LifespanComponent>
    {
        public float DeltaTime;

        [WriteOnly]
        public EntityCommandBuffer.Concurrent CommandBuffer;

        public void Execute(Entity entity, int jobIndex, ref AgeComponent age, ref LifespanComponent life)
        {
          // age.Value += DeltaTime;

            if (age.Value > life.Value)
            {
                CommandBuffer.DestroyEntity(jobIndex, entity);
            }
        }

     
    }


    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var commandBuffer = m_Barrier.CreateCommandBuffer().ToConcurrent();

        var job = new LifeTimeJob
        {
            DeltaTime = Time.DeltaTime,
            CommandBuffer = commandBuffer,

        }.Schedule(this, inputDependencies);

        m_Barrier.AddJobHandleForProducer(job);

        return job;
    }
}