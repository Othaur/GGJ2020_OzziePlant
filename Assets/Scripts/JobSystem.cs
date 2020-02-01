using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Mathematics;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;

public class JobSystem : MonoBehaviour
{
    [SerializeField] private bool useJobs;
    private void Update()
    {
        float startTime = Time.realtimeSinceStartup;
        if (useJobs)
        {
            NativeList<JobHandle> jobHandleList = new NativeList<JobHandle>(Allocator.Temp);    
            for (int i = 0; i < 10; i++)
            {
                JobHandle jobHandler = ReallyToughTaskJob();
                jobHandleList.Add(jobHandler);
            }
            JobHandle.CompleteAll(jobHandleList);
            jobHandleList.Dispose();
        }
        else
        {
            for (int i = 0; i < 10; i++)
                ReallyToughTask();
        }
        Debug.Log((Time.realtimeSinceStartup - startTime) * 1000f + "ms");
    }
    private void ReallyToughTask()
    {
        // Represents a tough task like some pathfinding or a really complex calculation
        float value = 0f;
        for (int i = 0; i < 50000; i++)
        {
            value = math.exp10(math.sqrt(value));
        }
    }

    private JobHandle ReallyToughTaskJob()
    {
        var job = new ReallyToughJob();
        return job.Schedule();
    }

    public struct ReallyToughJob : IJob
    {
        public void Execute()
        {
            float value = 0f;
            for (int i = 0; i < 50000; i++)
            {
                value = math.exp10(math.sqrt(value));
            }
        }
    }
}