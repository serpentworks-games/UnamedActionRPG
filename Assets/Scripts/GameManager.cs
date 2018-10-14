using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    Inventory inv;

    private void Awake()
    {
        inv = FindObjectOfType<Inventory>();
    }

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (inv.isActive)
        {
            Cursor.visible = true;
        } else
        {
           // Cursor.visible = false;
        }
	}
}
