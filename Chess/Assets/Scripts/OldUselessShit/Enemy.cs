using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	Transform playerTransform = null;

	NavMeshAgent agent;

	Vector3 prevPosition = Vector3.zero;

	private void Start()
	{
		playerTransform = FindObjectOfType<PlayerController>().transform;
		agent = GetComponent<NavMeshAgent>();
		prevPosition = transform.position;
	}

	private void Update()
	{
		//~~Activity 2: Make the enemy chase the player using NavMesh!
	}
}
