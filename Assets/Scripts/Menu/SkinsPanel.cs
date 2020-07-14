using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsPanel : MonoBehaviour
{
    [SerializeField] private Vehicle[] carsList;
    [SerializeField] private GameObject carField;
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject skinButtonPref;
    public static SkinsPanel instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Refresh(GameObject car)
    {
        string carName = SaveAndLoad.getSelectedCar();
        Vehicle selectedVehicle = Array.Find(carsList, x => x.vehicleName.Equals(carName));
        clearField();
        populateField(selectedVehicle);

        car.GetComponent<Image>().sprite = selectedVehicle.skins[SaveAndLoad.getSelectedSkin(carName)];
    }

    

    private void changeSkin(int i)
    {
        string carName = SaveAndLoad.getSelectedCar();
        Vehicle selectedVehicle = Array.Find(carsList, x => x.vehicleName == carName);
        SaveAndLoad.setSelectedSkin(carName, i);
        
        carField.transform.GetChild(0).GetComponent<Image>().sprite = selectedVehicle.skins[SaveAndLoad.getSelectedSkin(carName)];
    }


    private void clearField()
    {
        foreach (Transform child in container.transform)
        {
            Destroy(child.gameObject);
        }
    }
    private void populateField(Vehicle car)
    {
        for (int i = 0; i < car.skinsIcons.Length; i++)
        {
            int copy = i;
            skinButtonPref.GetComponent<Image>().sprite = car.skinsIcons[i];
            GameObject gameObject = Instantiate(skinButtonPref, container.transform);
            gameObject.GetComponent<Button>().onClick.AddListener(() => changeSkin(copy));
        }
    }
}
