using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    
    int StoreCount;

    public float BaseStoreCost;
    public float StoreCostFactor;

    public float CurrentCost;


    public float StoreEarnings;


    public Text StoreCountText;
    
    public Slider ProgressSlider;

    float CurrentTime;
    public float StoreTime; 


    // Use this for initialization
    void Start () {
        StoreCount = 1;        
        StoreCountText.text = StoreCount.ToString();                 

        CurrentCost = BaseStoreCost;
        CurrentTime = 0;
     

    }
	
	// Update is called once per frame
	void Update () {

        CurrentTime += Time.deltaTime;
        if (CurrentTime >= StoreTime)
        {
            CurrentTime = 0;            
            EarnMoney();
        }
        ProgressSlider.value = CurrentTime/StoreTime;

    }

    public void BuyStoreOnClick()
    {
        if (GameManager.Instance.CurrentBalance >= CurrentCost)
        {
            StoreCount += 1;
            StoreCountText.text = StoreCount.ToString();            
            
            GameManager.Instance.UpdateCurrentBalance(-CurrentCost);
            CurrentCost *= StoreCostFactor;
        }
    }

    public void EarnMoney()
    {              
        GameManager.Instance.UpdateCurrentBalance(StoreEarnings * StoreCount);
    }
}
