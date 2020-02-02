using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static SoundController Instance;

    public GameObject audioSource3D;

    private List<AudioSource> audioSources;

    public AudioClip[] seedCollectionClips;


    private void Awake()
    {
        audioSources = new List<AudioSource>();
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private AudioSource GetAudioSource()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
            {
                return audioSource;
            }
        }

        AudioSource addedSource = gameObject.AddComponent<AudioSource>();
        audioSources.Add(addedSource);
        return addedSource;
    }

    public void Play2D(AudioClip clip)
    {
        AudioSource source = GetAudioSource();
        source.clip = clip;
        source.Play();
    }

    public void Play3D(AudioClip clip, Vector3 position)
    {
        GameObject addedObject = Instantiate(audioSource3D, position, Quaternion.identity) as GameObject;
        AudioSource addedSource = addedObject.GetComponent<AudioSource>();
        addedSource.clip = clip;
        addedSource.Play();

    }

    public void PlayCollectSound()
    {
        //int index = Random.Range(0, seedCollectionClips.Length);
        Play2D(seedCollectionClips[0]);
    }
}