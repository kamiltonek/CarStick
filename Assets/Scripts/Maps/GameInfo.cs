using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : Singleton<GameInfo>
{
    private bool backIsGrounded;
    private bool frontIsGrounded;
    private bool end;
    private float time;

    public void endGame(bool finish)
    {
        if (!end)
        {
            end = true;
            Timer.instance.updateTime();
            if (finish)
            {
                SummaryScript.instance.showSuccesSummary();
            }
            else
            {
                SummaryScript.instance.showFailedSummary();
            }
        }     
    }
    public bool BackIsGrounded { get => backIsGrounded; set => backIsGrounded = value; }
    public bool FrontIsGrounded { get => frontIsGrounded; set => frontIsGrounded = value; }
    public bool End { get => end; set => end = value;  }
    public float Time { get => time; set => time = value; }
}
