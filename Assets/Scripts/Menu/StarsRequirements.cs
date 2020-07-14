using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Map/StarsRequirement")]
public class StarsRequirements : ScriptableObject
{
    public int map;
    public int level;
    public float [] star;
}
