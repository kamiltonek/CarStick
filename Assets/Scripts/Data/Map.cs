using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Map
{
    private float [,] tab;

    public Map()
    {
        tab = new float[20, 100];
    }

    public float getMapAtIndex(int map, int level)
    {
        return tab[map, level];
    }

    public void setMapAtIndex(int map, int level, float time)
    {
        tab[map, level] = time;
    }
}
