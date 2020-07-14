using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyAsset/Vehicle")]
public class Vehicle : ScriptableObject
{
    public string vehicleName;
    public GameObject vehicleImage;
    public Sprite[] skins;
    public Sprite[] skinsIcons;
    public AnimationCurve vehicleGripCost;
    public AnimationCurve speedCost;
    public AnimationCurve accelerationCost;
    public AnimationCurve turboCost;
    public AnimationCurve vehicleGripValue;
    public AnimationCurve speedValue;
    public AnimationCurve accelerationValue;
    public AnimationCurve turboValue;
    public float rotationSpeed;
    public float rotationSpeedInGround;
    public float maxRotationSpeed;
    public float maxReverseSpeed;
}
