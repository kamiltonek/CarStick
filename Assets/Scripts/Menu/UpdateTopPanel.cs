using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTopPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsAmount;
    [SerializeField] private StatsPanel statsPanel;

    void Update()
    {
        coinsAmount.text = SaveAndLoad.getCoinsAmount().ToString();
    }

    public void increaseCoins()
    {       
        SaveAndLoad.increaseCoinsAmount(10000);
        statsPanel.initialize();
    }
}
