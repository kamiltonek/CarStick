using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateSpeed : MonoBehaviour
{
    [SerializeField] private GameObject carController;

    private Vector3 lastPosition;
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = ((int)carController.transform.GetChild(0).GetComponent<Rigidbody2D>().velocity.magnitude).ToString();  
    }
}
