using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] private Slider barVehicleGrip;
    [SerializeField] private Slider barSpeed;
    [SerializeField] private Slider barAcceleration;
    [SerializeField] private Slider barTurbo;
    [SerializeField] private TextMeshProUGUI levelVehicleGrip;
    [SerializeField] private TextMeshProUGUI levelSpeed;
    [SerializeField] private TextMeshProUGUI levelAcceleration;
    [SerializeField] private TextMeshProUGUI levelTurbo;
    [SerializeField] private Image buttonVehicleGrip;
    [SerializeField] private Image buttonSpeed;
    [SerializeField] private Image buttonAcceleration;
    [SerializeField] private Image buttonTurbo;
    [SerializeField] private TextMeshProUGUI coinsAmountVehicleGrip;
    [SerializeField] private TextMeshProUGUI coinsAmountSpeed;
    [SerializeField] private TextMeshProUGUI coinsAmountAcceleration;
    [SerializeField] private TextMeshProUGUI coinsAmountTurbo;
    [SerializeField] private Vehicle [] carsList;
    [SerializeField] private GameObject carField;
    [SerializeField] private Sprite buttonBuyTrue;
    [SerializeField] private Sprite buttonBuyFalse;
    [SerializeField] private Sprite buttonBuyMax;

    private bool slide;
    private float time;
    private float slideSpeed = 1f;
    private int index = 0;

    void Start()
    {
        for (int i = 0; i < carsList.Length; i++)
        {
            if(carsList[i].vehicleName.Equals(SaveAndLoad.getSelectedCar()))
            {
                index = i;
            }
        }
        changeCar();
        initialize();
    }

    private void Update()
    {
        if (slide)
        {
            time += Time.deltaTime;
            if(time > 0.01f)
            {
                bool currSlide = false;
                if(barVehicleGrip.value != SaveAndLoad.getCurrVehicleGrip(carsList[index].vehicleName))
                {
                    barVehicleGrip.value += Mathf.Sign(SaveAndLoad.getCurrVehicleGrip(carsList[index].vehicleName) - barVehicleGrip.value) * slideSpeed;
                    currSlide = true;
                }
                if (barSpeed.value != SaveAndLoad.getCurrSpeed(carsList[index].vehicleName))
                {
                    barSpeed.value += Mathf.Sign(SaveAndLoad.getCurrSpeed(carsList[index].vehicleName) - barSpeed.value) * slideSpeed;
                    currSlide = true;
                }
                if (barAcceleration.value != SaveAndLoad.getCurrAcceleration(carsList[index].vehicleName))
                {
                    barAcceleration.value += Mathf.Sign(SaveAndLoad.getCurrAcceleration(carsList[index].vehicleName) - barAcceleration.value) * slideSpeed;
                    currSlide = true;
                }
                if (barTurbo.value != SaveAndLoad.getCurrTurbo(carsList[index].vehicleName))
                {
                    barTurbo.value += Mathf.Sign(SaveAndLoad.getCurrTurbo(carsList[index].vehicleName) - barTurbo.value) * slideSpeed;
                    currSlide = true;
                }

                if (!currSlide)
                {
                    slide = false;                 
                }
                time = 0;
            }
        }
    }

    public void initialize()
    {
        int myCoinsAmount = SaveAndLoad.getCoinsAmount();

//********************************************************************************************************************************************************

        int currVehicleGrip = SaveAndLoad.getCurrVehicleGrip(carsList[index].vehicleName);
        int vehicleGripUpCost = (int)carsList[index].vehicleGripCost.Evaluate(currVehicleGrip );
        levelVehicleGrip.text = currVehicleGrip.ToString() + "/30lv";
        coinsAmountVehicleGrip.text = vehicleGripUpCost.ToString();
        for (int i = 0; i < buttonVehicleGrip.gameObject.transform.childCount; i++)
        {
            buttonVehicleGrip.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        if (currVehicleGrip == 30)
        {
            buttonVehicleGrip.sprite = buttonBuyMax;
            for(int i = 0; i < buttonVehicleGrip.gameObject.transform.childCount; i++)
            {
                buttonVehicleGrip.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if(myCoinsAmount >= vehicleGripUpCost)
        {
            buttonVehicleGrip.sprite = buttonBuyTrue;
        }
        else
        {
            buttonVehicleGrip.sprite = buttonBuyFalse;
        }

//********************************************************************************************************************************************************

        int currSpeed = SaveAndLoad.getCurrSpeed(carsList[index].vehicleName);
        int speedUpCost = (int)carsList[index].speedCost.Evaluate(currSpeed);
        levelSpeed.text = currSpeed.ToString() + "/30lv";
        coinsAmountSpeed.text = speedUpCost.ToString();
        for (int i = 0; i < buttonSpeed.gameObject.transform.childCount; i++)
        {
            buttonSpeed.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        if (currSpeed == 30)
        {
            buttonSpeed.sprite = buttonBuyMax;
            for (int i = 0; i < buttonSpeed.gameObject.transform.childCount; i++)
            {
                buttonSpeed.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (myCoinsAmount >= speedUpCost)
        {
            buttonSpeed.sprite = buttonBuyTrue;
        }
        else
        {
            buttonSpeed.sprite = buttonBuyFalse;
        }

//********************************************************************************************************************************************************

        int currAcceleration = SaveAndLoad.getCurrAcceleration(carsList[index].vehicleName);
        int accelerationUpCost = (int)carsList[index].accelerationCost.Evaluate(currAcceleration);
        levelAcceleration.text = currAcceleration.ToString() + "/30lv";
        coinsAmountAcceleration.text = accelerationUpCost.ToString();
        for (int i = 0; i < buttonAcceleration.gameObject.transform.childCount; i++)
        {
            buttonAcceleration.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        if (currAcceleration == 30)
        {
            buttonAcceleration.sprite = buttonBuyMax;
            for (int i = 0; i < buttonAcceleration.gameObject.transform.childCount; i++)
            {
                buttonAcceleration.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (myCoinsAmount >= accelerationUpCost)
        {
            buttonAcceleration.sprite = buttonBuyTrue;
        }
        else
        {
            buttonAcceleration.sprite = buttonBuyFalse;
        }

//********************************************************************************************************************************************************

        int currTurbo = SaveAndLoad.getCurrTurbo(carsList[index].vehicleName);
        int turboUpCost = (int)carsList[index].turboCost.Evaluate(currTurbo);
        levelTurbo.text = currTurbo.ToString() + "/30lv";
        coinsAmountTurbo.text = turboUpCost.ToString();
        for (int i = 0; i < buttonTurbo.gameObject.transform.childCount; i++)
        {
            buttonTurbo.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        if (currTurbo == 30)
        {
            buttonTurbo.sprite = buttonBuyMax;
            for (int i = 0; i < buttonTurbo.gameObject.transform.childCount; i++)
            {
                buttonTurbo.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (myCoinsAmount >= turboUpCost)
        {
            buttonTurbo.sprite = buttonBuyTrue;
        }
        else
        {
            buttonTurbo.sprite = buttonBuyFalse;
        }
//********************************************************************************************************************************************************
        slide = true;
    }

    public void increaseVehicleGrip()
    {
        int currVehicleGrip = SaveAndLoad.getCurrVehicleGrip(carsList[index].vehicleName);
        int cost = (int)carsList[index].vehicleGripCost.Evaluate(currVehicleGrip);

        if (cost <= SaveAndLoad.getCoinsAmount() && currVehicleGrip < 30)
        {
            SaveAndLoad.decreaseCoinsAmount(cost);
            SaveAndLoad.increaseCurrVehicleGrip(carsList[index].vehicleName);
        }

        initialize();
    }

    public void increaseSpeed()
    {
        int currSpeed = SaveAndLoad.getCurrSpeed(carsList[index].vehicleName);
        int cost = (int)carsList[index].speedCost.Evaluate(currSpeed);

        if (cost <= SaveAndLoad.getCoinsAmount() && currSpeed < 30)
        {
            SaveAndLoad.decreaseCoinsAmount(cost);
            SaveAndLoad.increaseSpeed(carsList[index].vehicleName);
        }
        
        initialize();
    }

    public void increaseAcceleration()
    {
        int currAcceleration = SaveAndLoad.getCurrAcceleration(carsList[index].vehicleName);
        int cost = (int)carsList[index].accelerationCost.Evaluate(currAcceleration);

        if (cost <= SaveAndLoad.getCoinsAmount() && currAcceleration < 30)
        {
            SaveAndLoad.decreaseCoinsAmount(cost);
            SaveAndLoad.increaseAcceleration(carsList[index].vehicleName);
        }
        
        initialize();
    }

    public void increaseTurbo()
    {
        int currTurbo = SaveAndLoad.getCurrTurbo(carsList[index].vehicleName);
        int cost = (int)carsList[index].turboCost.Evaluate(currTurbo);
        
        if(cost <= SaveAndLoad.getCoinsAmount() && currTurbo < 30)
        {
            SaveAndLoad.decreaseCoinsAmount(cost);
            SaveAndLoad.increaseTurbo(carsList[index].vehicleName);
        }
        
        initialize();
    }

    public void showNextVehicle()
    {
        index = (index + 1) % carsList.Length;
        changeCar();
        initialize();
    }

    public void showPreviousVehicle()
    {
        index = (index - 1);
        if(index < 0)
        {
            index = carsList.Length - 1;
        }
        changeCar();
        initialize();
    }

    private void changeCar()
    {
        SaveAndLoad.setSelectedCar(carsList[index].vehicleName);
        Destroy(GameObject.Find("car"));
        GameObject newCar = Instantiate(carsList[index].vehicleImage, carField.transform.position, Quaternion.identity, carField.transform);
        newCar.name = "car";
        SkinsPanel.instance.Refresh(newCar);
    }
}
