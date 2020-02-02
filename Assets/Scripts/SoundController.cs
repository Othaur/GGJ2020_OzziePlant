using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static SoundController Instance;

    public GameObject audioSource3D;

    private List<AudioSource> audioSources;

    public AudioClip[] seedCollectionClips;

    public AudioClip[] planterClips;

    public AudioClip[] playerStepClips;

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
        addedSource.loop = false;
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

    public AudioClip GetRandomClip(AudioClip[] audioClips)
    {

        int index = Random.Range(0, audioClips.Length);
        return audioClips[index];
    }


}