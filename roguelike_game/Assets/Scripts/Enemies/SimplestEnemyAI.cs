﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimplestEnemyAI : MonoBehaviour
{

	[Header("AI Settings")]
	[SerializeField][Tooltip("Player GameObject that the AI will try to attack")]
    private Transform targetPlayer;
	[SerializeField][Tooltip("How fast the AI will rotate?")]
    private float rotationSpeed;
	[SerializeField][Tooltip("How fast will the AI walk?")]
    private float movementSpeed;
    [SerializeField][Range(0f,10f)][Tooltip("How far from the player will the AI stop walking and start shooting?")]
    private float safePlayerDistance;
	[SerializeField][Tooltip("The AI's Rigidbody2D component")]
    private Rigidbody2D rb;
    
    void Start()
    {
        
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
    	Vector3 vectorToTarget = targetPlayer.position - transform.position;
 		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
 		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
 		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);

 		float step = movementSpeed * Time.deltaTime;

        if(Vector3.Distance(transform.position, targetPlayer.position) > safePlayerDistance)
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, step);
        else if(Vector3.Distance(transform.position, targetPlayer.position) < safePlayerDistance - 0.2f)
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, -step);
    }
}