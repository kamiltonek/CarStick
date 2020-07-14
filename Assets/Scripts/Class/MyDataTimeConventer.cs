using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDataTimeConventer
{
    public static string getTime(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int miliseconds = (int)(Mathf.Floor((time - (seconds + minutes * 60)) * 1000));

        string result = "";
        if (minutes > 0)
        {
            result += minutes.ToString() + ":";
            if (seconds >= 10)
            {
                result += seconds.ToString() + ",";
            }
            else
            {
                result += "0" + seconds.ToString() + ",";
            }
            if (miliseconds < 10)
            {
                result += "00";
            }
            else if (miliseconds < 100)
            {
                result += "0";
            }
            result += miliseconds.ToString();
        }
        else
        {
            result += seconds.ToString() + ",";
            if (miliseconds < 10)
            {
                result += "00";
            }
            else if (miliseconds < 100)
            {
                result += "0";
            }
            result += miliseconds.ToString();
        }
        return result;
    }
}
