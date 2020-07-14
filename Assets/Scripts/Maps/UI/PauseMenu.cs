using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void openPauseMenu()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        GetComponent<Animator>().Play("openPause");
    }

    public void closePauseMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        
    }
}
