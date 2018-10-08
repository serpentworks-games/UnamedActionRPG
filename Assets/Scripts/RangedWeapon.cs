using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour {

    public float offset;
    public Transform shotPoint;
    public GameObject projectile;
    public float startTimeBtwShots;

    Inventory inv;
    DialogueUI diagUI;
    float timeBtwShots;

    private void Awake()
    {
        inv = GetComponentInParent<Inventory>();
        diagUI = FindObjectOfType<DialogueUI>();
    }

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(difference.x, difference.y, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!inv.isActive && !diagUI.isActive)
                {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                }
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
       
    }
}
