using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Car
{
    private int selectedSkin;
    private const int maxVehicleGrip = 30;
    private const int maxSpeed = 30;
    private const int maxAcceleration = 30;
    private const int maxTurbo = 30;

    private string carName;
    private int currVehicleGrip;
    private int currSpeed;
    private int currAcceleration;
    private int currTurbo;

    

    public Car(string carName)
    {
        this.carName = carName;
        this.currVehicleGrip = 1;
        this.currSpeed = 1;
        this.currAcceleration = 1;
        this.currTurbo = 1;
        selectedSkin = 0;
    }

    public int SelectedSkin { get => selectedSkin; set => selectedSkin = value; }
    public void increaseVehicleGrip()
    {
        if (currVehicleGrip < maxVehicleGrip)
        {
            currVehicleGrip++;
        }
    }

    public void increaseSpeed()
    {
        if (currSpeed < maxSpeed)
        {
            currSpeed++;
        }
    }

    public void increaseAcceleration()
    {
        if (currAcceleration < maxAcceleration)
        {
            currAcceleration++;
        }
    }

    public void increaseTurbo()
    {
        if (currTurbo < maxTurbo)
        {
            currTurbo++;
        }
    }

    public int getVehicleGrip()
    {
        return currVehicleGrip;
    }

    public int getSpeed()
    {
        return currSpeed;
    }

    public int getAcceleration()
    {
        return currAcceleration;
    }

    public int getTurbo()
    {
        return currTurbo;
    }

    public string getCarName()
    {
        return carName;
    }
}
