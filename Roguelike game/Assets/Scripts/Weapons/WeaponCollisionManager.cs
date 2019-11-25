﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisionManager : MonoBehaviour
{

	private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").TryGetComponent<PlayerManager>(out playerManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        playerManager.EnemyHit(col.gameObject);
    }
}