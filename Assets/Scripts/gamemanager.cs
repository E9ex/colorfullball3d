using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public UIManager uimanager;
    public admanager admanager;
    private void Start()
    {
        CoinCalculator(0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("finishline"))
        {
            Debug.Log("Oyun bitti");
            admanager.RequestInterstitial();
            admanager.RequestRewarded();
            CoinCalculator(100);
            Debug.Log(PlayerPrefs.GetInt("moneyy"));//savelenmiş değeri yazdıracaktır.
            uimanager.finishscreen();
        }
    }


    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldscore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy",oldscore+money);// eger yoksa 0 ataması yapsın.
        }
        else
            PlayerPrefs.SetInt("moneyy",0);
        
        
    }
}
