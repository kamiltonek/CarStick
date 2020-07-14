using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D backTire;
    [SerializeField] private Rigidbody2D carBody;
    [SerializeField] private GameObject flame;
    [SerializeField] private Vehicle vehicleInfo;

    private float rotationSpeed;
    private float rotationSpeedInGround;
    private float maxReverseSpeed;
    private float maxRotationSpeed;

    private float maxSpeed;
    private float acceleration;

    private void Start()
    {
        PhysicsMaterial2D tireMaterial = new PhysicsMaterial2D();
        tireMaterial.friction = vehicleInfo.vehicleGripValue.Evaluate(SaveAndLoad.getCurrVehicleGrip(vehicleInfo.vehicleName));

        maxSpeed = -vehicleInfo.speedValue.Evaluate(SaveAndLoad.getCurrSpeed(vehicleInfo.vehicleName));
        acceleration = vehicleInfo.accelerationValue.Evaluate(SaveAndLoad.getCurrAcceleration(vehicleInfo.vehicleName));
        rotationSpeed = vehicleInfo.rotationSpeed;
        rotationSpeedInGround = vehicleInfo.rotationSpeedInGround;
        maxReverseSpeed = vehicleInfo.maxReverseSpeed;
        maxRotationSpeed = vehicleInfo.maxRotationSpeed;

        backTire.gameObject.GetComponent<CircleCollider2D>().sharedMaterial = tireMaterial;
        
        carBody.centerOfMass = new Vector2(-1f, 0);
    }
    private void FixedUpdate()
    {
        Drive();
        Rotate();
        FallDown();
    }

    private void FallDown()
    {
        if (!GameInfo.Instance.BackIsGrounded && !GameInfo.Instance.FrontIsGrounded)
        {
            // Pobranie pozycji przodu auta oraz tyłu
            Vector2 front = GameObject.Find("front").transform.position;
            Vector2 back = GameObject.Find("back").transform.position;
            
            // Obliczenie nachylenia pojazdu
            float fallDownAngle = (front - back).y;

            if (fallDownAngle < 0)
            {
                // Uzależnienie nachylenia pojazdu do jego długości
                float carLength = Math.Abs(Vector2.Distance(front, back));
                fallDownAngle = Math.Abs(fallDownAngle) / carLength;

                carBody.AddForce(new Vector2(0, fallDownAngle * -40f));
            }
        }      
    }

    private void Drive()
    {
        if (!GameInfo.Instance.End)
        {
            if (InputManager.Instance.BreakIsPreessed && InputManager.Instance.GasIsPressed)
            {
                backTire.angularVelocity = 0;
            }
            else if(InputManager.Instance.GasIsPressed && backTire.angularVelocity > maxSpeed)
            {
                backTire.AddTorque(-acceleration * Time.deltaTime);
            }
            else if(InputManager.Instance.BreakIsPreessed && backTire.angularVelocity < maxReverseSpeed)
            {
                backTire.AddTorque(acceleration * Time.deltaTime);
            }
            else if(!InputManager.Instance.BreakIsPreessed && !InputManager.Instance.GasIsPressed)
            {
                backTire.AddTorque(-0.65f * backTire.angularVelocity * Time.deltaTime);
            }
        }
        else
        {
            backTire.AddTorque(-2f * backTire.angularVelocity * Time.deltaTime);
        }
    }

    private void Rotate()
    {
        if (!GameInfo.Instance.End)
        {
            if(!GameInfo.Instance.BackIsGrounded && !GameInfo.Instance.FrontIsGrounded && Math.Abs(carBody.angularVelocity) < maxRotationSpeed)
            {
                if (InputManager.Instance.BreakIsPreessed && InputManager.Instance.GasIsPressed)
                {
                    carBody.AddTorque(-45f * carBody.angularVelocity * Time.deltaTime);
                }
                else if(InputManager.Instance.GasIsPressed)
                {
                    if (carBody.angularVelocity < 0)
                    {
                        carBody.AddTorque(-150f * carBody.angularVelocity * Time.deltaTime);
                    }
                    carBody.AddTorque(rotationSpeed * Time.deltaTime);
                }
                else if (InputManager.Instance.BreakIsPreessed)
                {
                    if (carBody.angularVelocity > 0)
                    {
                        carBody.AddTorque(-150f * carBody.angularVelocity * Time.deltaTime);
                    }
                    carBody.AddTorque(-rotationSpeed * Time.deltaTime);
                }
                else
                {
                    carBody.AddTorque(-15f * carBody.angularVelocity * Time.deltaTime);
                    if (Math.Abs(carBody.angularVelocity) < 10)
                    {
                        carBody.AddTorque(-150f * carBody.angularVelocity * Time.deltaTime);
                    }
                }
            }
            else if (GameInfo.Instance.BackIsGrounded || GameInfo.Instance.FrontIsGrounded)
            {
                if (InputManager.Instance.GasIsPressed)
                {
                    carBody.AddTorque(rotationSpeedInGround * Time.deltaTime);
                }
                else if (InputManager.Instance.BreakIsPreessed)
                {
                    carBody.AddTorque(-rotationSpeedInGround * Time.deltaTime);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "rocket")
        {
            Vector2 front = GameObject.Find("front").transform.position;
            Vector2 back = GameObject.Find("back").transform.position;
            float boostValue = vehicleInfo.turboValue.Evaluate(SaveAndLoad.getCurrTurbo(vehicleInfo.vehicleName)); ;

            Vector2 boostDirection = front - back;
            carBody.AddForce(boostDirection * boostValue, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
            flame.GetComponent<ParticleSystem>().Play();
        }

        if(collision.tag == "DeadLine")
        {
            GameInfo.Instance.endGame(false);
        }
    }

}