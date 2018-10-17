using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject[] quickslotBackgrounds;

    public Texture2D cursor;

    Player player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectAbility()
    {
        if (!player.spellAbilityActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                quickslotBackgrounds[0].transform.gameObject.SetActive(true);
                quickslotBackgrounds[1].transform.gameObject.SetActive(false);
                quickslotBackgrounds[2].transform.gameObject.SetActive(false);
                player.spellAbilityActive = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                quickslotBackgrounds[0].transform.gameObject.SetActive(true);
                quickslotBackgrounds[1].transform.gameObject.SetActive(false);
                quickslotBackgrounds[2].transform.gameObject.SetActive(false);
                player.spellAbilityActive = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                quickslotBackgrounds[0].transform.gameObject.SetActive(false);
                quickslotBackgrounds[1].transform.gameObject.SetActive(false);
                quickslotBackgrounds[2].transform.gameObject.SetActive(true);
                player.spellAbilityActive = true;
            }
        }
        else if (player.spellAbilityActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                quickslotBackgrounds[0].transform.gameObject.SetActive(false);
                player.spellAbilityActive = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                quickslotBackgrounds[1].transform.gameObject.SetActive(false);
                player.spellAbilityActive = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                quickslotBackgrounds[2].transform.gameObject.SetActive(false);
                player.spellAbilityActive = false;
            }
        }
    }
}
