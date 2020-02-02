using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Rendering;

public class PlanterSystem : MonoBehaviour
{
    EntityManager entityManager;
    Entity treeEntityPrefab;
    public GameObject treePrefab;
   
    private void Awake()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        treeEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(treePrefab, World.Active);

    }
    //public GameObject plantLocation;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "plantLocation")
        {
            
            // Instantiate(seed, collision.transform.position, Quaternion.identity);
            SpawnTree(collision.transform.position);
            collision.gameObject.tag = "planted";
            Destroy(collision.gameObject);
            SoundController.Instance.Play3D(SoundController.Instance.GetRandomClip(SoundController.Instance.planterClips), collision.transform.position);
        }
    }

    void SpawnTree(Vector3 pos)
    {
        Entity entity = entityManager.Instantiate(treeEntityPrefab);

        entityManager.SetComponentData(entity, new AgeComponent { Value = 0 });
        // entityManager.SetComponentData(entity, new NonUniformScale { Value = new float3(1, 6, 1) });

        entityManager.SetComponentData(entity, new Translation { Value = new float3(pos.x, pos.y, pos.z) });

        entityManager.AddComponent(entity, typeof(SeedSpawnPoint));
        entityManager.SetComponentData(entity, new SeedSpawnPoint { Value = new float3(UnityEngine.Random.Range(-4,4), 0, UnityEngine.Random.Range(-4, 4)) });

        RenderMesh tempMesh = World.Active.EntityManager.GetSharedComponentData<RenderMesh>(entity);
        entityManager.SetSharedComponentData(entity, new RenderMesh { mesh = Settings.Stage1Prefab(), material = tempMesh.material });
    }

}
