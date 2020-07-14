using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StagesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject parentHolder;
    [SerializeField] private Sprite goldStar;
    [SerializeField] private GameObject [] starsHolder;
    public int map;
    public int level;
    private StarsRequirements requirement;

    void Start()
    {
        requirement = parentHolder.GetComponent<StageHolder>().getRequire(level);
        float myTime = SaveAndLoad.getMap(map, level);
        text.text = myTime.ToString("0.000");

        for(int i = 0; i < starsHolder.Length; i++)
        {
            if(requirement.star[i] >= myTime && myTime != 0)
            {
                starsHolder[i].GetComponent<Image>().sprite = goldStar;
            }
        }

    }

}
