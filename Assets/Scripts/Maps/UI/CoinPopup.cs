using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPopup : MonoBehaviour
{
    private float directionPopup;
    private float disappearTimer = 0.4f;
    private CanvasGroup spriteColorAlpha;
    void Start()
    {
        directionPopup = Random.Range(-100, 101);
        spriteColorAlpha = GetComponent<CanvasGroup>();
    }

    private void FixedUpdate()
    {
        float moveSpeed = 100f;
        transform.position += new Vector3(directionPopup * 1.1f, moveSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            spriteColorAlpha.alpha -= Time.deltaTime;
            if (spriteColorAlpha.alpha == 0)
            {
                Destroy(gameObject);
            }
        }
        return;
    }

}
