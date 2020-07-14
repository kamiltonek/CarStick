using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMovement : MonoBehaviour
{
    [SerializeField] private RectTransform menuContainer;
    [SerializeField] private float smoothSpeed = 0.1f;
    [SerializeField] private RectTransform [] panels;
    private Vector3 desiredPosition;
    private Vector3[] menuPositions;

    [SerializeField] private Image [] buttons;

    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite goldSprite;


    private void Start()
    {
        menuPositions = new Vector3[2];

        menuPositions[0] = menuContainer.anchoredPosition;
        menuPositions[1] = menuContainer.anchoredPosition + new Vector2(0, menuContainer.rect.height);

        MoveMenu(0);
    }

    private void Update()
    {
        foreach (RectTransform rt in panels)
        {
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, menuContainer.rect.height);
        }

        menuContainer.anchoredPosition = Vector3.Lerp(menuContainer.anchoredPosition, desiredPosition, smoothSpeed);
    }

    public void MoveMenu(int id)
    {
        foreach(Image i in buttons)
        {
            i.sprite = defaultSprite;
        } 
        buttons[id].sprite = goldSprite;

        desiredPosition = menuPositions[id];
    }
}
