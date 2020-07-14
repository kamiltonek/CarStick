using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSound : MonoBehaviour
{
    [SerializeField] private Sprite soundOn;
    [SerializeField] private Sprite soundOff;
    void Start()
    {
        if (SaveAndLoad.isSound())
        {
            GetComponent<Image>().sprite = soundOn;
        }
        else
        {
            GetComponent<Image>().sprite = soundOff;
        }
    }

    public void switchSound()
    {
        if (SaveAndLoad.isSound())
        {
            GetComponent<Image>().sprite = soundOff;
            SaveAndLoad.muteSound();
        }
        else
        {
            GetComponent<Image>().sprite = soundOn;
            SaveAndLoad.unmuteSound();
        }
    }
}
