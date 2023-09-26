using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{

    float BaseStoreCost;
    float BaseStoreProfit;

    int StoreCount;
    public Text StoreCountText;
    public Slider TimerSlider;
    public gamemanager GameManager;

    float StoreTimer = 4f;
    float CurrentTimer = 0;
    bool StartTimer;

    
    void Start()
    {

        StoreCount = 1;
        
        BaseStoreCost = 1.5f;
        BaseStoreProfit = .5f;
        
        StartTimer = false;
    }

    
    void Update()
    {
        if (StartTimer)
        {
            CurrentTimer += Time.deltaTime;
            if(CurrentTimer > StoreTimer)
            {
                StartTimer = false;
                CurrentTimer = 0f;
             
                GameManager.AddToBalance(BaseStoreProfit * StoreCount);
                
            }

            
        }

        TimerSlider.value = CurrentTimer / StoreTimer;

    }

    public void BuyStoreOnClick ()
    {
        if (!GameManager.CanBuy(BaseStoreCost))
            return;


        StoreCount = StoreCount + 1;
        Debug.Log(StoreCount);
        StoreCountText.text = StoreCount.ToString();
        GameManager.AddToBalance(-BaseStoreCost);
        
        
        
    }

    public void StoreOnClick()
    {
        if (!StartTimer)
        StartTimer = true;

    }



}

