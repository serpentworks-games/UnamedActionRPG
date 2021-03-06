﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDroppedItem : MonoBehaviour {

    public GameObject item;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 2);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
