using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    private enum Direction { Up, Down };
    private Direction direction;
    private Vector3 speed2 = Vector3.zero;
    private Vector3 startPosition;
    private const float range = 0.15f;
    private const float speed = 0.012f;
    void Start()
    {
        startPosition = transform.position;
        direction = Direction.Up;
    }

        private void FixedUpdate()
    {
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
}
