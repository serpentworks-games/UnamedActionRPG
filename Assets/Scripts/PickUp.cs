using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable {

    public GameObject itemButton;
    Inventory inv;

	// Use this for initialization
	void Start () {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inv.invSlots.Length; i++)
            {
                if (inv.isFull[i] == false)
                {
                    inv.isFull[i] = true;
                    Instantiate(itemButton, inv.invSlots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
