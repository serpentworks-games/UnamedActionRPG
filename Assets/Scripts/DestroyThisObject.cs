using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisObject : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Start () {
        Invoke("DestroyThis", lifetime);
	}
	
    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
