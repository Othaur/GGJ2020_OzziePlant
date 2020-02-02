using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlayerSound : MonoBehaviour
{
    RandomSound randomSound;

    Vector3 lastStep;

    public float stepDistance = 1.2f;

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
        if (Vector3.Distance(Settings.PlayerPosition, lastStep) > stepDistance)
        {
            SoundController.Instance.Play2D(SoundController.Instance.GetRandomClip(SoundController.Instance.playerStepClips));
            lastStep = Settings.PlayerPosition;
        }
    }
}