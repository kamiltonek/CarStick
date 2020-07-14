using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    [SerializeField] private Rigidbody2D backTire;
    private AudioSource carSound;

    private float startPitch;
    private bool breakSound;
    private bool gasSound;

    private void Start()
    {
        carSound = GetComponent<AudioSource>();
        startPitch = carSound.pitch;
    }
    private void Update()
    {
        playCarSound();
    }
    private void playCarSound()
    {
        if(SaveAndLoad.isSound() && carSound.mute == true)
        {
            carSound.mute = false;
        }
        else if(!SaveAndLoad.isSound() && carSound.mute == false)
        {
            carSound.mute = true;
        }
        
        // 
        if (InputManager.Instance.GasIsPressed && !InputManager.Instance.BreakIsPreessed && backTire.angularVelocity < 0 && !breakSound && !GameInfo.Instance.End)
        {
            float newPitch = GetComponent<Rigidbody2D>().velocity.magnitude / 10;
            if (newPitch + 0.5f < 2.9f)
            {
                carSound.pitch = newPitch + startPitch;
            }
            else
            {
                carSound.pitch = 2.9f;
            }
            gasSound = true;
            if (carSound.volume < 0.4f)
            {
                carSound.volume += 0.025f;
            }
        }
        else if (InputManager.Instance.BreakIsPreessed && !InputManager.Instance.GasIsPressed && backTire.angularVelocity > 100 && !gasSound && !GameInfo.Instance.End)
        {
            if (carSound.pitch < 0.8f)
            {
                carSound.pitch += 0.015f;
            }
            breakSound = true;
            if (carSound.volume < 0.4f)
            {
                carSound.volume += 0.01f;
            }
        }
        else
        {
            if (carSound.pitch > startPitch)
            {
                carSound.pitch -= 0.075f;
            }
            else
            {
                gasSound = false;
                breakSound = false;
            }
            if (carSound.volume > 0.15f)
            {
                carSound.volume -= 0.05f;
            }
        }
    }
}
