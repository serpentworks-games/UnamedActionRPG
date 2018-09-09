using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifetime;

	// Use this for initialization
	void Start () {
        Invoke("DestroyProjectile", lifetime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
