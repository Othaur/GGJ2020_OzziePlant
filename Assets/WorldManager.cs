using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class WorldManager : MonoBehaviour
{
    EntityManager entityManager;
    Entity treeEntityPrefab;
    public GameObject treePrefab;
    // Start is called before the first frame update

    private void Awake()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        treeEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(treePrefab, World.Active);
    }
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 temp = new Vector3(UnityEngine.Random.Range(-30, 30), 0, UnityEngine.Random.Range(-30, 30));
            SpawnTree(temp);
        }
    }

    void SpawnTree(Vector3 pos)
    {
        Entity entity = entityManager.Instantiate(treeEntityPrefab);

        entityManager.SetComponentData(entity, new Age { Value = 0 });
        // entityManager.SetComponentData(entity, new NonUniformScale { Value = new float3(1, 6, 1) });

        entityManager.SetComponentData(entity, new Translation { Value = new float3(pos.x, pos.y, pos.z) });
    }
}
