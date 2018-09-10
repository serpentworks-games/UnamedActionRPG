using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public GameObject explosionParticle;
    public LayerMask whatIsSolid;

    CamShake shake;

	// Use this for initialization
	void Start () {
        Invoke("DestroyProjectile", lifetime);
        shake = GameObject.FindObjectOfType<CamShake>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Error! Enemy must take damage!");
                hit.collider.GetComponent<Enemy>().TakeDamage(damage);
                DestroyProjectile();
            } else if (hit.collider.CompareTag("Player"))
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), hit.collider.gameObject.GetComponent<Collider2D>());
            } else
            {
                DestroyProjectile();
            }

            shake.CameraShake();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    void DestroyProjectile()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
