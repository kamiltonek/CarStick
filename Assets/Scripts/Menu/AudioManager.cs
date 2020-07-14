using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource musicSource;
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        switchMusic();
    }

    public void switchMusic()
    {
        if (SaveAndLoad.isMusic())
        {
            musicSource.mute = false;
        }
        else
        {
            musicSource.mute = true;
        }
    }
}
