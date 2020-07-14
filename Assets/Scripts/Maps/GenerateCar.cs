using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateCar : MonoBehaviour
{
    [SerializeField] private GameObject[] carsList;
    [SerializeField] private Vehicle[] carsSkins;
    private Transform parent;
    private GameObject spawnedCar;
    private Sprite skin;

    void Awake()
    {
        parent = GameObject.Find("Car Controller").GetComponent<Transform>();
        findCar();
        spawnedCar = Instantiate(spawnedCar, parent.position, Quaternion.identity, parent);
        Vector3 offset = new Vector3(spawnedCar.transform.GetChild(2).GetComponent<PolygonCollider2D>().bounds.size.x, 0, 0);
        Vector3 corrPosition = new Vector3(spawnedCar.transform.position.x - (offset.x / 2), 
                                           spawnedCar.transform.position.y, 
                                           spawnedCar.transform.position.z);
        spawnedCar.transform.position = corrPosition;
        
    }

    private void findCar()
    {
        spawnedCar = Array.Find(carsList, x => x.name.Equals(SaveAndLoad.getSelectedCar()));
        skin = Array.Find(carsSkins, x => x.vehicleName.Equals(SaveAndLoad.getSelectedCar()))
                    .skins[SaveAndLoad.getSelectedSkin(SaveAndLoad.getSelectedCar())];
        spawnedCar.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = skin;
    }
}
