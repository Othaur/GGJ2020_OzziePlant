﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public class Settings : MonoBehaviour
{

    static Settings instance;
    EntityManager entityManager;
    Entity treeEntityPrefab;

    public GameObject stage1TreePrefab;
    public GameObject stage2TreePrefab;

    static Mesh stage1TreeMesh;
    static Mesh stage2TreeMesh;

    public GameObject seedPrefab;
    static Entity SeedEntityPrefab;


    public float _growRate;
    public float _scaleRate;

    public static float growRate = 5;
    public static float ScaleRate;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        SeedEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(seedPrefab, World.Active);

        stage1TreeMesh = stage1TreePrefab.GetComponent<MeshFilter>().sharedMesh;
        stage2TreeMesh = stage2TreePrefab.GetComponent<MeshFilter>().sharedMesh;

        growRate = _growRate;
        ScaleRate = _scaleRate;
    }


    public static Mesh Stage1Prefab()
    {
        return stage1TreeMesh;
    }

    public static Mesh Stage2Prefab()
    {
        return stage2TreeMesh;
    }

    public static Entity SeedPrefab()
    {
        return SeedEntityPrefab;
    }

}
