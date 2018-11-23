using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour
{

    int StoreAmount;
    public Text StoreAmountText;

    public Slider ProgressSlider;



    public float StoreEarnings;

    public float StoreTime;
    public float CurrentTime;

    public float StoreBaseCost;
    public float StoreCostFactor;
    public float StoreCurrentCost;
    // Use this for initialization
    void Start()
    {
        StoreAmount = 0;
        StoreAmountText.text = StoreAmount.ToString();
        CurrentTime = 0;
        StoreCurrentCost = StoreBaseCost;

    }

    // Update is called once per frame
    void Update()
    {
        if (StoreAmount > 0)
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime < StoreTime)
            {
                ProgressSlider.value = CurrentTime / StoreTime;
            }
            else
            {
                CurrentTime = 0;
                EarnSomeMoney();
            }
        }
    }

    public void OnButtonClick()
    {
        if (GameManager.Instance.CurrentBalance < StoreCurrentCost)
        {
            return;
        }
        StoreAmount += 1;
        StoreAmountText.text = StoreAmount.ToString();
        GameManager.Instance.UpdateCurrentBalance(-StoreCurrentCost);
        StoreCurrentCost += StoreCurrentCost * StoreCostFactor;
        if (StoreAmount % 5 == 0)
        {
            StoreEarnings *= 2;
        }

    }

    public void EarnSomeMoney()
    {
        GameManager.Instance.UpdateCurrentBalance(StoreEarnings * StoreAmount);
    }
}
