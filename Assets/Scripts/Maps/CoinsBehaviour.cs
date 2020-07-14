using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsBehaviour : MonoBehaviour
{
    private enum Direction { Up, Down };
    private Direction direction;
    private Vector3 speed2 = Vector3.zero;
    private Vector3 startPosition;
    private const float range = 0.15f;
    private const float speed = 0.012f;
    private bool isDestroying = false;
    public int value;

    private float directionPopup;
    private float disappearTimer = 0.4f;
    private Color spriteColor;

    void Start()
    {
        startPosition = transform.position;
        direction = Direction.Up;
        directionPopup = Random.Range(-100, 101) / 100.0f;
        spriteColor = GetComponent<SpriteRenderer>().color;
    }

    private void FixedUpdate()
    {
        if (isDestroying)
        {
            float moveSpeed = 6f;
            transform.position += new Vector3(directionPopup * 1.1f, moveSpeed) * Time.deltaTime;

            disappearTimer -= Time.deltaTime;
            if (disappearTimer < 0)
            {
                spriteColor.a -= Time.deltaTime;
                GetComponent<SpriteRenderer>().color = spriteColor;
                if (spriteColor.a < 0)
                {
                    Destroy(gameObject);
                }
            }
            return;
        }

        if (direction == Direction.Up)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            if (transform.position.y >= startPosition.y + range)
            {
                direction = Direction.Down;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
            if (transform.position.y <= startPosition.y - range)
            {
                direction = Direction.Up;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car" && !isDestroying)
        {
            isDestroying = true;
            SaveAndLoad.increaseCoinsAmount(value);
        }
    }
}
