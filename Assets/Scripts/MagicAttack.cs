using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour {

    public GameObject quickSlot1;
    public GameObject quickSlot2;
    public GameObject quickSlot3;

    public Texture2D cursor;

    public bool abilityActive;
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

        SelectAbility();

        if (abilityActive)
        {
            Cursor.visible = true;
            Cursor.SetCursor(cursor, new Vector2(0,0), CursorMode.Auto);
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

    void SelectAbility()
    {
        if (!abilityActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                quickSlot1.transform.GetChild(0).gameObject.SetActive(true);
                quickSlot2.transform.GetChild(0).gameObject.SetActive(false);
                quickSlot3.transform.GetChild(0).gameObject.SetActive(false);
                abilityActive = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                quickSlot2.transform.GetChild(0).gameObject.SetActive(true);
                quickSlot1.transform.GetChild(0).gameObject.SetActive(false);
                quickSlot3.transform.GetChild(0).gameObject.SetActive(false);
                abilityActive = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                quickSlot1.transform.GetChild(0).gameObject.SetActive(false);
                quickSlot2.transform.GetChild(0).gameObject.SetActive(false);
                quickSlot3.transform.GetChild(0).gameObject.SetActive(true);
                abilityActive = true;
            }
        }
        else if (abilityActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                quickSlot1.transform.GetChild(0).gameObject.SetActive(false);
                abilityActive = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                quickSlot2.transform.GetChild(0).gameObject.SetActive(false);
                abilityActive = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                quickSlot3.transform.GetChild(0).gameObject.SetActive(false);
                abilityActive = false;
            }
        }
    }
}
