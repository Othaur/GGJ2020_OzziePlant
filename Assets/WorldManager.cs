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
    public GameObject plantSpotPrefab;
    // Start is called before the first frame update

    private void Awake()
    {
    //    entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
     //   treeEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(treePrefab, World.Active);
    }
    void Start()
    {
        for (int x = -8; x < 8; x++)
        {
            for (int y = -8; y < 8; y++)
            {
                if (UnityEngine.Random.Range(0, 2) == 1)
                {
                    Vector3 temp = new Vector3(x * 2, 0, y * 2);
                    SpawnTreePoint(temp);
                }
            }
        }
    }

    void SpawnTreePoint(Vector3 pos)
    {

        Instantiate(plantSpotPrefab, pos, quaternion.identity);

       // Entity entity = entityManager.Instantiate(treeEntityPrefab);

      //  entityManager.SetComponentData(entity, new AgeComponent { Value = 0 });
        // entityManager.SetComponentData(entity, new NonUniformScale { Value = new float3(1, 6, 1) });

       // entityManager.SetComponentData(entity, new Translation { Value = new float3(pos.x, pos.y, pos.z) });
    }
}
