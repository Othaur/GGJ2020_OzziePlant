using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomSound : MonoBehaviour
{
    public AudioClip[] audioClips;

    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomClip()
    {

        int index = Random.Range(0, audioClips.Length);

        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

}