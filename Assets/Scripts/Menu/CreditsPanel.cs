using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void openPanel()
    {
        panel.SetActive(true);
        GetComponent<Animator>().Play("openCredits");
    }

    public void closePanel()
    {
        panel.SetActive(false);
    }
}
