using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvSlot : MonoBehaviour {

    Inventory inv;
    public int i;

	// Use this for initialization
	void Start () {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount <= 0)
        {
            inv.isFull[i] = false;
        }
	}
    public void DiscardItem()
    {
        foreach (Transform item in transform)
        {
            item.GetComponent<SpawnDroppedItem>().SpawnItem();
            GameObject.Destroy(item.gameObject);
        }
    }
}
