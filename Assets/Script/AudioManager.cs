using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Audio[] sound;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Audio a in sound)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;

            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
            a.source.loop = a.loop;
        }        
    }

    private void Start()
    {
        PlayAudio("Theme");
    }

    public void PlayAudio (string name)
    {
        Audio a = Array.Find(sound, audio => audio.name == name);
        if (a == null)
            return;
        a.source.Play();
    }

    public void StopAudio()
    {

    }
}
