using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public bool[] isFull;
    public GameObject[] invSlots;
    public GameObject inventoryUI;
    public bool isActive;

    private void Start()
    {
        isActive = false;
        inventoryUI.SetActive(isActive);
    }

    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isActive == true)
            {
                isActive = false;
                inventoryUI.SetActive(isActive);
                Time.timeScale = 1;
                
            }
            else if (isActive == false)
            {
                isActive = true;
                inventoryUI.SetActive(isActive);
                Time.timeScale = 0;
            }

        }
    }
}
