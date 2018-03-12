using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Audio;
using UnityEngine;

public class AudioBackground : MonoBehaviour, IAudio
{

    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public bool isPlaying;
    public bool Interacted;

    void Start()
    {
        MusicSource.clip = MusicClip;
        isPlaying = false;
        Interacted = false;
    }

    void Update()
    {
        if(!isPlaying)
            Play();
    }

    public void Play()
    {
        MusicSource.Play();
        isPlaying = true;
    }

    public void Pause()
    {
        throw new System.NotImplementedException();
    }
}
