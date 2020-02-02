using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlayerSound : MonoBehaviour
{
    RandomSound randomSound;

    Vector3 lastStep;

    public float stepDistance = 0.5f;

    private void Awake()
    {
        randomSound = GetComponent<RandomSound>();
    }

    private void Start()
    {
        lastStep = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, lastStep) > stepDistance)
        {
            randomSound.PlayRandomClip();
            lastStep = transform.position;
        }
    }
}