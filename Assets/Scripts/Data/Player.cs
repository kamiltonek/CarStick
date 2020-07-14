using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player
{
    private int coinsAmount;
    private int gemsAmount;
    private string selectedCar;
    private bool music;
    private bool sound;

    public Player()
    {
        CoinsAmount = 0;
        GemsAmount = 100;
        selectedCar = "car1";
        Music = true;
        Sound = true;
    }

    public int CoinsAmount { get => coinsAmount; set => coinsAmount = value; }
    public int GemsAmount { get => gemsAmount; set => gemsAmount = value; }
    public string SelectedCar { get => selectedCar; set => selectedCar = value; }
    public bool Music { get => music; set => music = value; }
    public bool Sound { get => sound; set => sound = value; }
}
