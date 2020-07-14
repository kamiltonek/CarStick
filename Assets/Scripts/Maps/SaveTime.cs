using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTime : MonoBehaviour
{
    public int map;
    public int level;
    private bool save;
    public static SaveTime instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    public void Save()
    {
        if (save)
            return;
        float myTime = GameInfo.Instance.Time;
        float bestTime = SaveAndLoad.getMap(map, level);

        if (myTime < bestTime || bestTime == 0f)
        {
            SaveAndLoad.setMap(map, level, myTime);
        }
        save = true;
    }
}
