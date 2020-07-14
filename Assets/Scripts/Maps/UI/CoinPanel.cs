using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinAmount;
    
    public void Update()
    {
        coinAmount.text = SaveAndLoad.getCoinsAmount().ToString();
    }
}
