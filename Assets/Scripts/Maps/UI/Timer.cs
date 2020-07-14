using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    private Text text;
    private float startTime;
    private bool start;
    float currTime;
    private bool save;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void StartTimer()
    {
        if (!start)
        {
            text = GetComponent<Text>();
            startTime = Time.time;
            start = true;
        }
    }

    void Update()
    {
        updateTime();
    }

    public void updateTime()
    {
        if (start && !GameInfo.Instance.End)
        {
            currTime = Time.time - startTime;

            text.text = MyDataTimeConventer.getTime(currTime);
        }
        else if (GameInfo.Instance.End && !save)
        {
            GameInfo.Instance.Time = currTime;           
            save = true;
        }
    }
}
    
