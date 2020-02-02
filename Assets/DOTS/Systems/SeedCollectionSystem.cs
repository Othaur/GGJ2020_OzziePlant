using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;
using Unity.Burst;

public class SeedCollectionSystem : JobComponentSystem
{

    EntityCommandBufferSystem m_Barrier;

    protected override void OnCreate()
    {
        m_Barrier = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }
    /*
    protected override JobHandle OnUpdate( JobHandle jobHandle)
    {
        Vector3 playerPosition = PlayerController.main.transform.position;
        
        JobHandle collisionJob = Entities.ForEach((ref ColliderComponent collider, ref Translation translation) =>
        {
            float dist = Mathf.Abs(translation.Value.x - playerPosition.x) + Mathf.Abs(translation.Value.z - playerPosition.z);
            if(dist < collider.size)
            {
            }
            //Vector3.Distance(playerPosition, collider.size);
        }).Schedule(jobHandle);
        
        return collisionJob;
    }*/
    //[BurstCompile]
    struct LifeTimeJob : IJobForEachWithEntity<ColliderComponent, Translation>
    {
        public Vector3 PlayerPosition;

        [WriteOnly]
        public EntityCommandBuffer.Concurrent CommandBuffer;


        public void Execute(Entity entity, int jobIndex, ref ColliderComponent collider, ref Translation translation)
        {
            float dist = Mathf.Abs(translation.Value.x - PlayerPosition.x) + Mathf.Abs(translation.Value.z - PlayerPosition.z);

            if (dist < collider.size)
            {
                CommandBuffer.DestroyEntity(jobIndex, entity);    
                Settings.AddSeed();
                //SoundController.Instance.PlayCollectSound();
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var commandBuffer = m_Barrier.CreateCommandBuffer().ToConcurrent();
        Vector3 tempPos = Settings.PlayerPosition;
    
        var job = new LifeTimeJob
        {
            PlayerPosition = tempPos,
            CommandBuffer = commandBuffer,


        }.Schedule(this, inputDependencies);

        m_Barrier.AddJobHandleForProducer(job);
       
        return job;
    }
}