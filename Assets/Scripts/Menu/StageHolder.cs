using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageHolder : MonoBehaviour
{
    [SerializeField] private StarsRequirements[] requirements;
    [SerializeField] private TextMeshProUGUI totalStars;
    void Start()
    {
        int starsAmount = 0;

        foreach(StarsRequirements req in requirements)
        {
            float myTime = SaveAndLoad.getMap(req.map, req.level);
            for(int i = 0; i < req.star.Length; i++)
            {
                if(myTime != 0 && myTime <= req.star[i])
                {
                    starsAmount++;
                }
            }
        }
        totalStars.text = starsAmount + "/" + requirements.Length * requirements[0].star.Length;

    }

    public StarsRequirements getRequire(int level)
    {
        return requirements[level];
    }
}
