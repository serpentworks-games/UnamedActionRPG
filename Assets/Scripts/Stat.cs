using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {

    private Image content;
    private float currentFill;

    public float MaxValue { get; set; }

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {

            if (value > MaxValue)
            {
                currentValue = MaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }

            currentFill = currentValue / MaxValue;
        }
    }

    private float currentValue;

	// Use this for initialization
	void Start () {
        content = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        content.fillAmount = currentFill;
	}

    public void InitializeStats(float currentValue, float maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = currentValue;
    }
}
