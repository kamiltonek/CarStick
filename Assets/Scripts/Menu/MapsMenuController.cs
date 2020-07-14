using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mapsPanel;
    [SerializeField] private RectTransform container;
    [SerializeField] private GameObject[] elements;
    [SerializeField] private RectTransform center;

    [SerializeField] private GameObject[] stagesPanel;

    private float[] distance;
    private bool dragging = false;
    private int bttnDistance;
    private int minButtonNum;

    private void Start()
    {
        int bttnLength = elements.Length;
        distance = new float[bttnLength];

        bttnDistance = (int)Mathf.Abs(elements[1].GetComponent<RectTransform>().anchoredPosition.x -
                                      elements[0].GetComponent<RectTransform>().anchoredPosition.x);
        
    }
    private void Update()
    {
        for(int i = 0; i < elements.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - elements[i].transform.position.x);
        }

        float minDistance = Mathf.Min(distance);

        for (int i = 0; i < elements.Length; i++)
        {
            if(minDistance == distance[i])
            {
                minButtonNum = i;
            }
        }

        if (!dragging)
        {
            LerpToBttn(minButtonNum * -bttnDistance);
        }
    }

    private void LerpToBttn(int position)
    {
        float newX = Mathf.Lerp(container.anchoredPosition.x, position, Time.deltaTime * 10f);

        Vector2 newPosition = new Vector2(newX, container.anchoredPosition.y);

        container.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }

    public void openStagesPanel()
    {
        mapsPanel.SetActive(false);
        stagesPanel[minButtonNum].SetActive(true);
    }

    public void openMapsPanel()
    {
        stagesPanel[minButtonNum].SetActive(false);
        mapsPanel.SetActive(true);
    }

}
