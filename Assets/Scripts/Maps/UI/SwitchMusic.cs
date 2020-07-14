using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMusic : MonoBehaviour
{
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;
    void Start()
    {
        if (SaveAndLoad.isMusic())
        {
            GetComponent<Image>().sprite = musicOn;
        }
        else
        {
            GetComponent<Image>().sprite = musicOff;
        }
    }

    public void switchMusic()
    {
        if (SaveAndLoad.isMusic())
        {
            GetComponent<Image>().sprite = musicOff;
            SaveAndLoad.muteMusic();
        }
        else
        {
            GetComponent<Image>().sprite = musicOn;
            SaveAndLoad.unmuteMusic();
        }
        AudioManager.Instance.switchMusic();
    }
}
