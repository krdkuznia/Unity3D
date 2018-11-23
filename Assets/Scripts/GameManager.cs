using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public static GameManager Instance = null;
    public float CurrentBalance;
    public Text CurrentBalanceText;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else 
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    // Use this for initialization
    void Start () {
        CurrentBalance = 1f;
        CurrentBalanceText.text = CurrentBalance.ToString("C2", CultureInfo.CreateSpecificCulture("pl-PL"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateCurrentBalance(float amount)
    {
        CurrentBalance += amount;
        CurrentBalanceText.text = CurrentBalance.ToString("C2", CultureInfo.CreateSpecificCulture("pl-PL"));
    }
}
