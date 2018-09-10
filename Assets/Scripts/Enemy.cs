using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health < 0)
        {
            Debug.Log("Enemy is dead!");
        }
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
