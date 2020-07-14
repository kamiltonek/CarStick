using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{ 
    [SerializeField] Transform cameraTransform;

    private MeshRenderer meshRenderer;
    private Vector2 cameraLastPosition;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        cameraLastPosition = cameraTransform.position;
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(0, 0));
    }

    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        // Pobranie aktualnego przesunięcia tekstury oraz wyliczenie nowego.
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");
        Vector2 distance = (-(cameraLastPosition - (Vector2)cameraTransform.position)) / new Vector2(1200, 1000);
        distance.x += .00005f;
        offset += distance;
        
        cameraLastPosition = cameraTransform.position;
        // Ustawienie nowego przesunięcia tekstury
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
