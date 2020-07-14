using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private Vector3 offset;
    private GameObject car;
    private float smoothSpeed = 10f;
    private float carSpeedPrev;
    private Vector3 targetLastPosition;
    private float targetLastSpeed;

    private float minCameraSize = 12;
    private float maxCameraSize = 20;
    private void Start()
    {
        offset = new Vector3(0, 5, -10);
        car = target.transform.GetChild(0).gameObject;
        carSpeedPrev = car.GetComponent<Rigidbody2D>().velocity.magnitude;
        targetLastPosition = car.transform.position;
        targetLastSpeed = car.GetComponent<Rigidbody2D>().velocity.magnitude;
    }
    private void FixedUpdate()
    {
        if (!GameInfo.Instance.End)
        {
            moveCamera();   
        }
        else
        {
            float endSmoothSpeed = 0.05f * targetLastSpeed;
            Vector3 desiredPosition = targetLastPosition + getDistance() + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, endSmoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
            if(GetComponent<Camera>().orthographicSize > minCameraSize)
            {
                GetComponent<Camera>().orthographicSize -= 0.05f;
            }
        }
    }

    private void moveCamera()
    {
        Vector3 desiredPosition = car.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;          

        // Wyliczenie wartości determinuijącej prekość
        // oddalania i przybliżania kamery
        float carSpeed = car.GetComponent<Rigidbody2D>().velocity.magnitude;
        float smoothedCarSpeed;

        if (Math.Abs(carSpeed - carSpeedPrev) > 0.1f)
        {
            smoothedCarSpeed = carSpeedPrev + 0.1f * Math.Sign(carSpeed - carSpeedPrev);
        }
        else
        {
            smoothedCarSpeed = (carSpeed + carSpeedPrev) / 2;
        }
        
        // Ustawienie oddalenia kamery
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(minCameraSize, maxCameraSize, Time.deltaTime * smoothedCarSpeed);

        carSpeedPrev = smoothedCarSpeed;

        targetLastPosition = car.transform.position;
        targetLastSpeed = car.GetComponent<Rigidbody2D>().velocity.magnitude;      
    }
    
    private Vector3 getDistance()
    {
        float maxDistance = 0.5f * targetLastSpeed;

        Vector3 v1 = targetLastPosition;
        Vector3 v2 = car.transform.position;
        Vector3 distance = new Vector3(v2.x - v1.x, v2.y - v1.y, v2.z - v1.z);
        distance.x = Math.Min(Math.Abs(distance.x), Math.Abs(maxDistance)) * Math.Sign(distance.x);
        distance.y = Math.Min(Math.Abs(distance.y), Math.Abs(maxDistance)) * Math.Sign(distance.y);
        distance.z = Math.Min(Math.Abs(distance.z), Math.Abs(maxDistance)) * Math.Sign(distance.z);

        return distance;
    }
}
